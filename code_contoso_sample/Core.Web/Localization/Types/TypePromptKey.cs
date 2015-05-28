using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using Core.Web.Localization.Views;

namespace Core.Web.Localization.Types
{
    /// <summary>
    /// Type prompt key.
    /// </summary>
    /// <remarks>The key is only unique for the current language only. This is a requirement
    /// to be able to translate prompts between languages</remarks>
    [DataContract]
    public class TypePromptKey : IEquatable<TypePromptKey>
    {
        [DataMember] private readonly string _id;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewPromptKey"/> class.
        /// </summary>
        /// <param name="fullTypeName">Type.FullName for the type getting localized.</param>
        /// <param name="name">Property name (and metadata name prefixed with underscore).</param>
        public TypePromptKey(string fullTypeName, string name)
        {
            if (fullTypeName == null) throw new ArgumentNullException("type");
            if (name == null) throw new ArgumentNullException("name");

            var md5 = new MD5CryptoServiceProvider();
            var retVal = md5.ComputeHash(Encoding.UTF8.GetBytes(fullTypeName + name));
            var sb = new StringBuilder();
            for (var i = 0; i < retVal.Length; i++)
                sb.Append(retVal[i].ToString("x2"));
            _id = sb.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewPromptKey"/> class.
        /// </summary>
        /// <param name="md5Hash">Already computed hash.</param>
        public TypePromptKey(string md5Hash)
        {
            if (md5Hash == null) throw new ArgumentNullException("md5Hash");
            _id = md5Hash;
        }

        #region IEquatable<TypePromptKey> Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(TypePromptKey other)
        {
            return other != null && other._id.Equals(_id);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typePromptKey"></param>
        /// <param name="typePromptKey2"></param>
        /// <returns></returns>
        public static bool operator ==(TypePromptKey typePromptKey, TypePromptKey typePromptKey2)
        {
            if ((object) typePromptKey == null || ((object) typePromptKey2) == null)
                return Equals(typePromptKey, typePromptKey2);

            return typePromptKey.Equals(typePromptKey2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewPromptKey"></param>
        /// <param name="viewPromptKey2"></param>
        /// <returns></returns>
        public static bool operator !=(TypePromptKey viewPromptKey, TypePromptKey viewPromptKey2)
        {
            if (viewPromptKey == null || viewPromptKey2 == null)
                return !Equals(viewPromptKey, viewPromptKey2);

            return !(viewPromptKey.Equals(viewPromptKey2));
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _id;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TypePromptKey)) return false;
            return Equals((TypePromptKey) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return (_id != null ? _id.GetHashCode() : 0);
        }
    }
}