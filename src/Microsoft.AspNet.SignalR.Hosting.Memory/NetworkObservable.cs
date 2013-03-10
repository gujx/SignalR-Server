﻿using System;

namespace Microsoft.AspNet.SignalR.Hosting.Memory
{
    public class NetworkObservable : INetworkObserver
    {
        private readonly bool _disableWrites;

        public NetworkObservable(bool disableWrites)
        {
            _disableWrites = disableWrites;
        }

        public Action<ArraySegment<byte>> OnWrite { get; set; }
 
        public Action OnClose { get; set; }
        
        public Action OnCancel { get; set; }

        public void Write(byte[] buffer, int offset, int count)
        {
            if (_disableWrites)
            {
                return;
            }

            if (OnWrite != null)
            {
                OnWrite(new ArraySegment<byte>(buffer, offset, count));
            }
        }

        public void Close()
        {
            if (OnClose != null)
            {
                OnClose();
            }
        }

        public void Cancel()
        {
            if (OnCancel != null)
            {
                OnCancel();
            }
        }
    }
}