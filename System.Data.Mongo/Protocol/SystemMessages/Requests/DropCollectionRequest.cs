﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.Mongo.Protocol.SystemMessages.Requests
{
    public class DropCollectionRequest
    {
        public DropCollectionRequest(String collectionName)
        {
            this.drop = collectionName;
        }
        public String drop { get; protected set; }
    }
}