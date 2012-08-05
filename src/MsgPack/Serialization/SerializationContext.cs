#region -- License Terms --
//
// MessagePack for CLI
//
// Copyright (C) 2010 FUJIWARA, Yusuke
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
#endregion -- License Terms --

using System;
#if !SILVERLIGHT
using System.Collections.Concurrent;
#endif
using System.Collections.Generic;
using System.Diagnostics.Contracts;
#if NETFX_CORE
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
#endif
#if SILVERLIGHT
using System.Threading;
#endif

namespace MsgPack.Serialization
{
	/// <summary>
	///		<strong>This is intened to MsgPack for CLI internal use. Do not use this type from application directly.</strong>
	///		Represents serialization context information for internal serialization logic.
	/// </summary>
	public sealed class SerializationContext
	{
		private readonly SerializerRepository _serializers;
#if SILVERLIGHT
		private readonly object _typeLock;
#else
		private readonly ConcurrentDictionary<Type, object> _typeLock;
#endif

		/// <summary>
		///		Gets the current <see cref="SerializerRepository"/>.
		/// </summary>
		/// <value>
		///		The  current <see cref="SerializerRepository"/>.
		/// </value>
		public SerializerRepository Serializers
		{
			get
			{
				Contract.Ensures( Contract.Result<SerializerRepository>() != null );

				return this._serializers;
			}
		}

		private EmitterFlavor _emitterFlavor = EmitterFlavor.FieldBased;

		/// <summary>
		///		Gets or sets the <see cref="EmitterFlavor"/>.
		/// </summary>
		/// <value>
		///		The <see cref="EmitterFlavor"/>
		/// </value>
		/// <remarks>
		///		For testing purposes.
		/// </remarks>
		internal EmitterFlavor EmitterFlavor
		{
			get { return this._emitterFlavor; }
			set { this._emitterFlavor = value; }
		}

		private readonly SerializationCompatibilityOptions _compatibilityOptions;

		/// <summary>
		///		Gets the compatibility options.
		/// </summary>
		/// <value>
		///		The <see cref="SerializationCompatibilityOptions"/> which stores compatibility options. This value will not be <c>null</c>.
		/// </value>
		public SerializationCompatibilityOptions CompatibilityOptions
		{
			get
			{
				Contract.Ensures( Contract.Result<SerializationCompatibilityOptions>() != null );

				return this._compatibilityOptions;
			}
		}

		private SerializationMethod _serializationMethod;

		/// <summary>
		///		Gets or sets the <see cref="SerializationMethod"/> to determine serialization strategy.
		/// </summary>
		/// <value>
		///		The <see cref="SerializationMethod"/> to determine serialization strategy.
		/// </value>
		public SerializationMethod SerializationMethod
		{
			get
			{
				Contract.Ensures( Enum.IsDefined( typeof( SerializationMethod ), Contract.Result<SerializationMethod>() ) );

				return this._serializationMethod;
			}
			set
			{
				switch ( value )
				{
					case Serialization.SerializationMethod.Array:
					case Serialization.SerializationMethod.Map:
					{
						break;
					}
					default:
					{
						throw new ArgumentOutOfRangeException( "value" );
					}
				}

				Contract.EndContractBlock();

				this._serializationMethod = value;
			}
		}

		private SerializationMethodGeneratorOption _generatorOption;

		/// <summary>
		///		Gets or sets the <see cref="SerializationMethodGeneratorOption"/> to control code generation.
		/// </summary>
		/// <value>
		///		The <see cref="SerializationMethodGeneratorOption"/>.
		/// </value>
		public SerializationMethodGeneratorOption GeneratorOption
		{
			get
			{
				Contract.Ensures( Enum.IsDefined( typeof( SerializationMethod ), Contract.Result<SerializationMethodGeneratorOption>() ) );

				return this._generatorOption;
			}
			set
			{
				switch ( value )
				{
					case SerializationMethodGeneratorOption.Fast:
#if !SILVERLIGHT
					case SerializationMethodGeneratorOption.CanCollect:
					case SerializationMethodGeneratorOption.CanDump:
#endif
					{
						break;
					}
					default:
					{
						throw new ArgumentOutOfRangeException( "value" );
					}
				}

				Contract.EndContractBlock();

				this._generatorOption = value;
			}
		}

		/// <summary>
		///		Initializes a new instance of the <see cref="SerializationContext"/> class with copy of <see cref="SerializerRepository.Default"/>.
		/// </summary>
		public SerializationContext()
			: this( new SerializerRepository( SerializerRepository.Default ) ) { }

		internal SerializationContext( SerializerRepository serializers )
		{
			Contract.Requires( serializers != null );

			this._compatibilityOptions = new SerializationCompatibilityOptions();
			this._serializers = serializers;
#if SILVERLIGHT
			this._typeLock = new object();
#else
			this._typeLock = new ConcurrentDictionary<Type, object>();
#endif
		}

		/// <summary>
		///		Gets the <see cref="MessagePackSerializer{T}"/> with this instance.
		/// </summary>
		/// <typeparam name="T">Type of serialization/deserialization target.</typeparam>
		/// <returns>
		///		<see cref="MessagePackSerializer{T}"/>.
		///		If there is exiting one, returns it.
		///		Else the new instance will be created.
		/// </returns>
		/// <remarks>
		///		This method automatically register new instance via <see cref="M:SerializationRepository.Register{T}"/>.
		/// </remarks>
		public MessagePackSerializer<T> GetSerializer<T>()
		{
			Contract.Ensures( Contract.Result<MessagePackSerializer<T>>() != null );

			var serializer = this._serializers.Get<T>( this );
			if ( serializer == null )
			{
				bool lockTaken = false;
				try
				{
					try { }
					finally
					{
#if SILVERLIGHT
						lockTaken = Monitor.TryEnter( this._typeLock );
#else
						lockTaken = this._typeLock.TryAdd( typeof( T ), null );
#endif
					}

					if ( !lockTaken )
					{
						return new LazyDelegatingMessagePackSerializer<T>( this );
					}

					serializer = MessagePackSerializer.Create<T>( this );
				}
				finally
				{
					if ( lockTaken )
					{
#if SILVERLIGHT
						Monitor.Exit( this._typeLock );
#else
						object dummy;
						this._typeLock.TryRemove( typeof( T ), out dummy );
#endif
					}
				}

				if ( !this._serializers.Register<T>( serializer ) )
				{
					serializer = this._serializers.Get<T>( this );
				}
			}

			return serializer;
		}

		/// <summary>
		///		Gets the serializer for the specified <see cref="Type"/>.
		/// </summary>
		/// <param name="targetType">Type of the serialization target.</param>
		/// <returns>
		///		<see cref="IMessagePackSerializer"/>.
		///		If there is exiting one, returns it.
		///		Else the new instance will be created.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		///		<paramref name="targetType"/> is <c>null</c>.
		/// </exception>
		/// <remarks>
		///		Although <see cref="GetSerializer{T}"/> is preferred,
		///		this method can be used from non-generic type or methods.
		/// </remarks>
		public IMessagePackSerializer GetSerializer( Type targetType )
		{
			if ( targetType == null )
			{
				throw new ArgumentNullException( "targetType" );
			}

			Contract.Ensures( Contract.Result<IMessagePackSerializer>() != null );

			return SerializerGetter.Instance.Get( this, targetType );
		}

		private sealed class SerializerGetter
		{
			public static readonly SerializerGetter Instance = new SerializerGetter();

			private readonly Dictionary<RuntimeTypeHandle, Func<SerializationContext, IMessagePackSerializer>> _cache =
				new Dictionary<RuntimeTypeHandle, Func<SerializationContext, IMessagePackSerializer>>();

			private SerializerGetter() { }

			public IMessagePackSerializer Get( SerializationContext context, Type targetType )
			{
				Func<SerializationContext, IMessagePackSerializer> func;
				if ( !this._cache.TryGetValue( targetType.TypeHandle, out func ) || func == null )
				{
#if !NETFX_CORE
					func =
						Delegate.CreateDelegate(
							typeof( Func<SerializationContext, IMessagePackSerializer> ),
							typeof( SerializerGetter<> ).MakeGenericType( targetType ).GetMethod( "Get" )
						) as Func<SerializationContext, IMessagePackSerializer>;
#else
					var contextParameter = Expression.Parameter( typeof( SerializationContext ), "context" );
					func =
						Expression.Lambda<Func<SerializationContext, IMessagePackSerializer>>(
							Expression.Call(
								null,
								typeof( SerializerGetter<> ).MakeGenericType( targetType ).GetRuntimeMethods().Single( m => m.Name == "Get" ),
								contextParameter
							),
							contextParameter
						).Compile();
#endif
					this._cache[ targetType.TypeHandle ] = func;
				}

				return func( context );
			}
		}

		private static class SerializerGetter<T>
		{
#if !NETFX_CORE
			private static readonly Func<SerializationContext, MessagePackSerializer<T>> _func =
				Delegate.CreateDelegate(
					typeof( Func<SerializationContext, MessagePackSerializer<T>> ),
					Metadata._SerializationContext.GetSerializer1_Method.MakeGenericMethod( typeof( T ) )
				) as Func<SerializationContext, MessagePackSerializer<T>>;
#else
			private static readonly Func<SerializationContext, MessagePackSerializer<T>> _func =
				CreateFunc();

			private static Func<SerializationContext, MessagePackSerializer<T>> CreateFunc()
			{
				var thisParameter = Expression.Parameter( typeof( SerializationContext ), "this" );
				return
					Expression.Lambda<Func<SerializationContext, MessagePackSerializer<T>>>(
						Expression.Call(
							thisParameter,
							Metadata._SerializationContext.GetSerializer1_Method.MakeGenericMethod( typeof( T ) )
						),
						thisParameter
					).Compile();
			}
#endif

			public static IMessagePackSerializer Get( SerializationContext context )
			{
				return _func( context );
			}
		}
	}
}
