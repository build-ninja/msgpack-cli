﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.34014
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MsgPack.Serialization.GeneratedSerializers.MapBased {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MsgPack.Serialization.CodeDomSerializers.CodeDomSerializerBuilder", "0.5.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class MsgPack_Serialization_StringKeyedCollection_1_System_Int32_Serializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.StringKeyedCollection<int>> {
        
        private MsgPack.Serialization.MessagePackSerializer<int> _serializer0;
        
        public MsgPack_Serialization_StringKeyedCollection_1_System_Int32_Serializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            this._serializer0 = context.GetSerializer<int>();
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.StringKeyedCollection<int> objectTree) {
            packer.PackArrayHeader(objectTree.Count);
            System.Collections.Generic.IEnumerator<int> enumerator = objectTree.GetEnumerator();
            int current;
            try {
                for (
                ; enumerator.MoveNext(); 
                ) {
                    current = enumerator.Current;
                    this._serializer0.PackTo(packer, current);
                }
            }
            finally {
                enumerator.Dispose();
            }
        }
        
        protected internal override MsgPack.Serialization.StringKeyedCollection<int> UnpackFromCore(MsgPack.Unpacker unpacker) {
            if ((unpacker.IsArrayHeader == false)) {
                throw MsgPack.Serialization.SerializationExceptions.NewIsNotArrayHeader();
            }
            MsgPack.Serialization.StringKeyedCollection<int> collection = default(MsgPack.Serialization.StringKeyedCollection<int>);
            collection = new MsgPack.Serialization.StringKeyedCollection<int>();
            this.UnpackToCore(unpacker, collection);
            return collection;
        }
        
        protected internal override void UnpackToCore(MsgPack.Unpacker unpacker, MsgPack.Serialization.StringKeyedCollection<int> collection) {
            if ((unpacker.IsArrayHeader == false)) {
                throw MsgPack.Serialization.SerializationExceptions.NewIsNotArrayHeader();
            }
            int count = default(int);
            count = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
            for (int i = 0; (i < count); i = (i + 1)) {
                System.Nullable<int> nullable = default(System.Nullable<int>);
                nullable = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.StringKeyedCollection<int>), string.Format(System.Globalization.CultureInfo.InvariantCulture, "item{0}", new object[] {
                                ((object)(i))}));
                if (nullable.HasValue) {
                    collection.Add(nullable.Value);
                }
                else {
                    throw MsgPack.Serialization.SerializationExceptions.NewValueTypeCannotBeNull(string.Format(System.Globalization.CultureInfo.InvariantCulture, "item{0}", new object[] {
                                    ((object)(i))}), typeof(int), typeof(MsgPack.Serialization.StringKeyedCollection<int>));
                }
            }
        }
        
        private static T @__Conditional<T>(bool condition, T whenTrue, T whenFalse)
         {
            if (condition) {
                return whenTrue;
            }
            else {
                return whenFalse;
            }
        }
    }
}
