#region License
// /*
// Microsoft Public License (Ms-PL)
// MonoGame - Copyright � 2009-2010 The MonoGame Team
// 
// All rights reserved.
// 
// This license governs use of the accompanying software. If you use the software, you accept this license. If you do not
// accept the license, do not use the software.
// 
// 1. Definitions
// The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under 
// U.S. copyright law.
// 
// A "contribution" is the original software, or any additions or changes to the software.
// A "contributor" is any person that distributes its contribution under this license.
// "Licensed patents" are a contributor's patent claims that read directly on its contribution.
// 
// 2. Grant of Rights
// (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, 
// each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
// (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, 
// each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
// 
// 3. Conditions and Limitations
// (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
// (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, 
// your patent license from such contributor to the software ends automatically.
// (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution 
// notices that are present in the software.
// (D) If you distribute any portion of the software in source code form, you may do so only under this license by including 
// a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object 
// code form, you may only do so under a license that complies with this license.
// (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees
// or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent
// permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular
// purpose and non-infringement.
// */
#endregion License

using System;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.Input.Touch
{
    /// <summary>
    /// Provides state information for a touch screen enabled device.
    /// </summary>
    public struct TouchCollection : IList<TouchLocation>
    {
        private TouchLocation[] _collection;

        #region Properties

        /// <summary>
        /// States if a touch screen is available.
        /// </summary>
        public bool IsConnected { get { return TouchPanel.GetCapabilities().IsConnected; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TouchCollection"/> with a pre-determined set of touch locations.
        /// </summary>
        /// <param name="touches">Array of <see cref="TouchLocation"/> items to initialize with.</param>
        public TouchCollection(TouchLocation[] touches)
        {
            if (touches == null)
                throw new ArgumentNullException("touches");

            _collection = touches;
        }

        /// <summary>
        /// Returns <see cref="TouchLocation"/> specified by ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="touchLocation"></param>
        /// <returns></returns>
        public bool FindById(int id, out TouchLocation touchLocation)
        {
            for (var i = 0; i < _collection.Length; i++)
            {
                var location = _collection[i];
                if (location.Id == id)
                {
                    touchLocation = location;
                    return true;
                }
            }

            touchLocation = default(TouchLocation);
            return false;
        }

        #region IList<TouchLocation>

        /// <summary>
        /// States if touch collection is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return true; }
        }

        /// <summary>
        /// Returns the index of the first occurrence of specified <see cref="TouchLocation"/> item in the collection.
        /// </summary>
        /// <param name="item"><see cref="TouchLocation"/> to query.</param>
        /// <returns></returns>
        public int IndexOf(TouchLocation item)
        {
            for (var i = 0; i < _collection.Length; i++)
            {
                if (item == _collection[i])
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// Inserts a <see cref="TouchLocation"/> item into the indicated position.
        /// </summary>
        /// <param name="index">The position to insert into.</param>
        /// <param name="item">The <see cref="TouchLocation"/> item to insert.</param>
        public void Insert(int index, TouchLocation item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Removes the <see cref="TouchLocation"/> item at specified index.
        /// </summary>
        /// <param name="index">Index of the item that will be removed from collection.</param>
        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets or sets the item at the specified index of the collection.
        /// </summary>
        /// <param name="index">Position of the item.</param>
        /// <returns><see cref="TouchLocation"/></returns>
        public TouchLocation this[int index]
        {
            get
            {
                return _collection[index];
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Adds a <see cref="TouchLocation"/> to the collection.
        /// </summary>
        /// <param name="item">The <see cref="TouchLocation"/> item to be added. </param>
        public void Add(TouchLocation item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Clears all the items in collection.
        /// </summary>
        public void Clear()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns true if specified <see cref="TouchLocation"/> item exists in the collection, false otherwise./>
        /// </summary>
        /// <param name="item">The <see cref="TouchLocation"/> item to query for.</param>
        /// <returns>Returns true if queried item is found, false otherwise.</returns>
        public bool Contains(TouchLocation item)
        {
            for (var i = 0; i < _collection.Length; i++)
            {
                if (item == _collection[i])
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Copies the <see cref="TouchLocation "/>collection to specified array starting from the given index.
        /// </summary>
        /// <param name="array">The array to copy <see cref="TouchLocation"/> items.</param>
        /// <param name="arrayIndex">The starting index of the copy operation.</param>
        public void CopyTo(TouchLocation[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns the number of <see cref="TouchLocation"/> items that exist in the collection.
        /// </summary>
        public int Count
        {
            get
            {
                if (_collection != null)
                    return _collection.Length;
                else
                    return 0;
            }
        }

        /// <summary>
        /// Removes the specified <see cref="TouchLocation"/> item from the collection.
        /// </summary>
        /// <param name="item">The <see cref="TouchLocation"/> item to remove.</param>
        /// <returns></returns>
        public bool Remove(TouchLocation item)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Returns an enumerator for the <see cref="TouchCollection"/>.
        /// </summary>
        /// <returns>Enumerable list of <see cref="TouchLocation"/> objects.</returns>
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Returns an enumerator for the <see cref="TouchCollection"/>.
        /// </summary>
        /// <returns>Enumerable list of <see cref="TouchLocation"/> objects.</returns>
        IEnumerator<TouchLocation> IEnumerable<TouchLocation>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Returns an enumerator for the <see cref="TouchCollection"/>.
        /// </summary>
        /// <returns>Enumerable list of objects.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        #endregion // IList<TouchLocation>

        /// <summary>
        /// Provides the ability to iterate through the TouchLocations in an TouchCollection.
        /// </summary>
        public struct Enumerator : IEnumerator<TouchLocation>
        {
            private readonly TouchCollection _collection;
            private int _position;

            internal Enumerator(TouchCollection collection)
            {
                _collection = collection;
                _position = -1;
            }

            /// <summary>
            /// Gets the current element in the TouchCollection.
            /// </summary>
            public TouchLocation Current { get { return _collection[_position]; } }

            /// <summary>
            /// Advances the enumerator to the next element of the TouchCollection.
            /// </summary>
            public bool MoveNext()
            {
                _position++;
                return (_position < _collection.Count);
            }

            #region IDisposable

            /// <summary>
            /// Immediately releases the unmanaged resources used by this object.
            /// </summary>
            public void Dispose()
            {
            }

            #endregion

            #region IEnumerator Members

            object IEnumerator.Current
            {
                get { return _collection[_position]; }
            }

            public void Reset()
            {
                _position = -1;
            }

            #endregion
        }
    }
}