﻿/*
 * Copyright 2021-Present The Serverless Workflow Specification Authors
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using Newtonsoft.Json.Linq;
using ServerlessWorkflow.Sdk.Models;
using System;
using YamlDotNet.Core;

namespace YamlDotNet.Serialization
{

    /// <summary>
    /// Represents the <see cref="IYamlTypeConverter"/> used to serialize and deserialize <see cref="Any"/> instances
    /// </summary>
    public class AnyConverter
        : IYamlTypeConverter
    {

        /// <inheritdoc/>
        public virtual bool Accepts(Type type)
        {
            return typeof(Any).IsAssignableFrom(type);
        }

        /// <inheritdoc/>
        public virtual object ReadYaml(IParser parser, Type type)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public virtual void WriteYaml(IEmitter emitter, object? value, Type type)
        {
            if (value == null)
                return;
            var token = JToken.FromObject(value);
            new JTokenSerializer().WriteYaml(emitter, token, typeof(JToken));
        }

    }

}