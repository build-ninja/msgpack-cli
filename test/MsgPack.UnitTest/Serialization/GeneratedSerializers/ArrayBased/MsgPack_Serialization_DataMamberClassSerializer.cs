﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.34014
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MsgPack.Serialization.GeneratedSerializers.ArrayBased {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("MsgPack.Serialization.CodeDomSerializers.CodeDomSerializerBuilder", "0.5.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class MsgPack_Serialization_DataMamberClassSerializer : MsgPack.Serialization.MessagePackSerializer<MsgPack.Serialization.DataMamberClass> {
        
        private MsgPack.Serialization.MessagePackSerializer<int> _serializer0;
        
        private MsgPack.Serialization.MessagePackSerializer<System.Collections.Generic.List<int>> _serializer1;
        
        private System.Reflection.FieldInfo _fieldDataMamberClass_NonPublicField0;
        
        private System.Reflection.FieldInfo _fieldDataMamberClass_NonSerializedNonPublicField1;
        
        private System.Reflection.MethodBase _methodBaseDataMamberClass_get_NonPublicProperty0;
        
        private System.Reflection.MethodBase _methodBaseDataMamberClass_set_NonPublicProperty1;
        
        public MsgPack_Serialization_DataMamberClassSerializer(MsgPack.Serialization.SerializationContext context) : 
                base(context) {
            this._serializer0 = context.GetSerializer<int>();
            this._serializer1 = context.GetSerializer<System.Collections.Generic.List<int>>();
            this._fieldDataMamberClass_NonPublicField0 = typeof(MsgPack.Serialization.DataMamberClass).GetField("NonPublicField", (System.Reflection.BindingFlags.Instance 
                            | (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)));
            this._fieldDataMamberClass_NonSerializedNonPublicField1 = typeof(MsgPack.Serialization.DataMamberClass).GetField("NonSerializedNonPublicField", (System.Reflection.BindingFlags.Instance 
                            | (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)));
            this._methodBaseDataMamberClass_get_NonPublicProperty0 = typeof(MsgPack.Serialization.DataMamberClass).GetMethod("get_NonPublicProperty", (System.Reflection.BindingFlags.Instance 
                            | (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)), null, new System.Type[0], null);
            this._methodBaseDataMamberClass_set_NonPublicProperty1 = typeof(MsgPack.Serialization.DataMamberClass).GetMethod("set_NonPublicProperty", (System.Reflection.BindingFlags.Instance 
                            | (System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic)), null, new System.Type[] {
                        typeof(int)}, null);
        }
        
        protected internal override void PackToCore(MsgPack.Packer packer, MsgPack.Serialization.DataMamberClass objectTree) {
            packer.PackArrayHeader(10);
            this._serializer0.PackTo(packer, objectTree.PublicProperty);
            this._serializer0.PackTo(packer, objectTree.PublicField);
            packer.PackNull();
            packer.PackNull();
            this._serializer0.PackTo(packer, ((int)(this._methodBaseDataMamberClass_get_NonPublicProperty0.Invoke(objectTree, null))));
            this._serializer0.PackTo(packer, ((int)(this._fieldDataMamberClass_NonPublicField0.GetValue(objectTree))));
            this._serializer0.PackTo(packer, objectTree.NonSerializedPublicField);
            packer.PackNull();
            this._serializer0.PackTo(packer, ((int)(this._fieldDataMamberClass_NonSerializedNonPublicField1.GetValue(objectTree))));
            this._serializer1.PackTo(packer, objectTree.CollectionReadOnlyProperty);
        }
        
        protected internal override MsgPack.Serialization.DataMamberClass UnpackFromCore(MsgPack.Unpacker unpacker) {
            MsgPack.Serialization.DataMamberClass result = default(MsgPack.Serialization.DataMamberClass);
            result = new MsgPack.Serialization.DataMamberClass();
            if (unpacker.IsArrayHeader) {
                int unpacked = default(int);
                int itemsCount = default(int);
                itemsCount = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                System.Nullable<int> nullable = default(System.Nullable<int>);
                if ((unpacked < itemsCount)) {
                    nullable = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 PublicProperty");
                }
                if (nullable.HasValue) {
                    result.PublicProperty = nullable.Value;
                }
                unpacked = (unpacked + 1);
                System.Nullable<int> nullable0 = default(System.Nullable<int>);
                if ((unpacked < itemsCount)) {
                    nullable0 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 PublicField");
                }
                if (nullable0.HasValue) {
                    result.PublicField = nullable0.Value;
                }
                unpacked = (unpacked + 1);
                unpacker.Read();
                unpacker.Read();
                System.Nullable<int> nullable1 = default(System.Nullable<int>);
                if ((unpacked < itemsCount)) {
                    nullable1 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 NonPublicProperty");
                }
                if (nullable1.HasValue) {
                    this._methodBaseDataMamberClass_set_NonPublicProperty1.Invoke(result, new object[] {
                                ((object)(nullable1.Value))});
                }
                unpacked = (unpacked + 1);
                System.Nullable<int> nullable2 = default(System.Nullable<int>);
                if ((unpacked < itemsCount)) {
                    nullable2 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 NonPublicField");
                }
                if (nullable2.HasValue) {
                    this._fieldDataMamberClass_NonPublicField0.SetValue(result, ((object)(nullable2.Value)));
                }
                unpacked = (unpacked + 1);
                System.Nullable<int> nullable3 = default(System.Nullable<int>);
                if ((unpacked < itemsCount)) {
                    nullable3 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 NonSerializedPublicField");
                }
                if (nullable3.HasValue) {
                    result.NonSerializedPublicField = nullable3.Value;
                }
                unpacked = (unpacked + 1);
                unpacker.Read();
                System.Nullable<int> nullable4 = default(System.Nullable<int>);
                if ((unpacked < itemsCount)) {
                    nullable4 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 NonSerializedNonPublicField");
                }
                if (nullable4.HasValue) {
                    this._fieldDataMamberClass_NonSerializedNonPublicField1.SetValue(result, ((object)(nullable4.Value)));
                }
                unpacked = (unpacked + 1);
                System.Collections.Generic.List<int> nullable5 = default(System.Collections.Generic.List<int>);
                if ((unpacked < itemsCount)) {
                    if ((unpacker.Read() == false)) {
                        throw MsgPack.Serialization.SerializationExceptions.NewMissingItem(9);
                    }
                    if (((unpacker.IsArrayHeader == false) 
                                && (unpacker.IsMapHeader == false))) {
                        nullable5 = this._serializer1.UnpackFrom(unpacker);
                    }
                    else {
                        MsgPack.Unpacker disposable = default(MsgPack.Unpacker);
                        disposable = unpacker.ReadSubtree();
                        try {
                            nullable5 = this._serializer1.UnpackFrom(disposable);
                        }
                        finally {
                            if (((disposable == null) 
                                        == false)) {
                                disposable.Dispose();
                            }
                        }
                    }
                }
                if (((nullable5 == null) 
                            == false)) {
                    System.Collections.Generic.List<int>.Enumerator enumerator = nullable5.GetEnumerator();
                    int current;
                    try {
                        for (
                        ; enumerator.MoveNext(); 
                        ) {
                            current = enumerator.Current;
                            result.CollectionReadOnlyProperty.Add(current);
                        }
                    }
                    finally {
                        enumerator.Dispose();
                    }
                }
                unpacked = (unpacked + 1);
            }
            else {
                int itemsCount0 = default(int);
                itemsCount0 = MsgPack.Serialization.UnpackHelpers.GetItemsCount(unpacker);
                for (int i = 0; (i < itemsCount0); i = (i + 1)) {
                    string key = default(string);
                    string nullable6 = default(string);
                    nullable6 = MsgPack.Serialization.UnpackHelpers.UnpackStringValue(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "MemberName");
                    if (((nullable6 == null) 
                                == false)) {
                        key = nullable6;
                    }
                    else {
                        throw MsgPack.Serialization.SerializationExceptions.NewNullIsProhibited("MemberName");
                    }
                    if ((key == "CollectionReadOnlyProperty")) {
                        System.Collections.Generic.List<int> nullable13 = default(System.Collections.Generic.List<int>);
                        if ((unpacker.Read() == false)) {
                            throw MsgPack.Serialization.SerializationExceptions.NewMissingItem(i);
                        }
                        if (((unpacker.IsArrayHeader == false) 
                                    && (unpacker.IsMapHeader == false))) {
                            nullable13 = this._serializer1.UnpackFrom(unpacker);
                        }
                        else {
                            MsgPack.Unpacker disposable0 = default(MsgPack.Unpacker);
                            disposable0 = unpacker.ReadSubtree();
                            try {
                                nullable13 = this._serializer1.UnpackFrom(disposable0);
                            }
                            finally {
                                if (((disposable0 == null) 
                                            == false)) {
                                    disposable0.Dispose();
                                }
                            }
                        }
                        if (((nullable13 == null) 
                                    == false)) {
                            System.Collections.Generic.List<int>.Enumerator enumerator0 = nullable13.GetEnumerator();
                            int current0;
                            try {
                                for (
                                ; enumerator0.MoveNext(); 
                                ) {
                                    current0 = enumerator0.Current;
                                    result.CollectionReadOnlyProperty.Add(current0);
                                }
                            }
                            finally {
                                enumerator0.Dispose();
                            }
                        }
                    }
                    else {
                        if ((key == "NonSerializedNonPublicField")) {
                            System.Nullable<int> nullable12 = default(System.Nullable<int>);
                            nullable12 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 NonSerializedNonPublicField");
                            if (nullable12.HasValue) {
                                this._fieldDataMamberClass_NonSerializedNonPublicField1.SetValue(result, ((object)(nullable12.Value)));
                            }
                        }
                        else {
                            if ((key == "NonSerializedPublicField")) {
                                System.Nullable<int> nullable11 = default(System.Nullable<int>);
                                nullable11 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 NonSerializedPublicField");
                                if (nullable11.HasValue) {
                                    result.NonSerializedPublicField = nullable11.Value;
                                }
                            }
                            else {
                                if ((key == "NonPublicField")) {
                                    System.Nullable<int> nullable10 = default(System.Nullable<int>);
                                    nullable10 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 NonPublicField");
                                    if (nullable10.HasValue) {
                                        this._fieldDataMamberClass_NonPublicField0.SetValue(result, ((object)(nullable10.Value)));
                                    }
                                }
                                else {
                                    if ((key == "NonPublicProperty")) {
                                        System.Nullable<int> nullable9 = default(System.Nullable<int>);
                                        nullable9 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 NonPublicProperty");
                                        if (nullable9.HasValue) {
                                            this._methodBaseDataMamberClass_set_NonPublicProperty1.Invoke(result, new object[] {
                                                        ((object)(nullable9.Value))});
                                        }
                                    }
                                    else {
                                        if ((key == "PublicField")) {
                                            System.Nullable<int> nullable8 = default(System.Nullable<int>);
                                            nullable8 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 PublicField");
                                            if (nullable8.HasValue) {
                                                result.PublicField = nullable8.Value;
                                            }
                                        }
                                        else {
                                            if ((key == "Alias")) {
                                                System.Nullable<int> nullable7 = default(System.Nullable<int>);
                                                nullable7 = MsgPack.Serialization.UnpackHelpers.UnpackNullableInt32Value(unpacker, typeof(MsgPack.Serialization.DataMamberClass), "Int32 PublicProperty");
                                                if (nullable7.HasValue) {
                                                    result.PublicProperty = nullable7.Value;
                                                }
                                            }
                                            else {
                                                unpacker.Skip();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
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
