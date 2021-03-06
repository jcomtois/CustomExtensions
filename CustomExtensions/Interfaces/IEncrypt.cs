﻿#region License and Terms

// CustomExtensions - Custom Extension Methods For C#
// Copyright (c) 2011 - 2012 Jonathan Comtois. All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

namespace CustomExtensions.Interfaces
{
    /// <summary>
    /// Provides AES Decryption function
    /// </summary>
    public interface IEncrypt : IAESCrypto
    {
        /// <summary>
        /// Encrypts <paramref name="source"/> using provided <paramref name="password"/>
        /// </summary>
        /// <param name="source">String to Encrypt</param>
        /// <param name="password">Password to use for encryption</param>
        /// <returns>Encrypted string.</returns>
        string EncryptAES(string source, string password);
    }
}