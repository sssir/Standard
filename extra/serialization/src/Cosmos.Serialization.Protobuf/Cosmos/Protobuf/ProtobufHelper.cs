﻿using System;
using System.IO;
using ProtoBuf.Meta;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

namespace Cosmos.Protobuf
{
    public static class ProtobufHelper
    {
        private static readonly Lazy<RuntimeTypeModel> _lazyModel = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        private static RuntimeTypeModel Model => _lazyModel.Value;

        public static byte[] Serialize<T>(T t)
        {
            return Serialize(t, typeof(T));
        }

        public static byte[] Serialize(object obj, Type type)
        {
            SerializerBuilder.Build(Model, type);
            var ms = new MemoryStream();
            Model.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static void Serialize(Stream dest, object value)
        {
            var type = value.GetType();
            SerializerBuilder.Build(Model, type);
            Model.Serialize(dest, value);
        }

        public static T Deserialize<T>(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return default(T);
            return (T)Deserialize(bytes, typeof(T));
        }


        public static object Deserialize(byte[] bytes, Type type)
        {
            if (bytes == null || bytes.Length == 0)
                return null;
            return Deserialize(new MemoryStream(bytes), type);
        }

        public static T Deserialize<T>(Stream stream)
        {
            return (T)Deserialize(stream, typeof(T));
        }

        public static object Deserialize(Stream stream, Type type)
        {
            SerializerBuilder.Build(Model, type);
            if (stream.CanSeek)
                stream.Position = 0;
            return Model.Deserialize(stream, null, type);
        }


        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }
    }
}
