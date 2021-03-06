﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace NoRM
{
    public class MongoConnection : TcpClient
    {
        public static readonly string DEFAULT_SERVER = "127.0.0.1";
        public static readonly int DEFAULT_PORT = 27017;

        // temp hack, going back and retro'ing pooling before replication
        public MongoConnection() 
            : base(DEFAULT_SERVER, DEFAULT_PORT)
        {
            this.TimeCreated = DateTime.Now;

            this.LeftServer = DEFAULT_SERVER;
            this.LeftPort = DEFAULT_PORT;
        }

        public MongoConnection(string leftServer, int leftPort)
            : this(leftServer, leftPort, DEFAULT_SERVER, DEFAULT_PORT, false)
        {
        }

        public MongoConnection(string leftServer, int leftPort, string rightServer, int rightPort)
            : this(leftServer, leftPort, rightServer, rightPort, false)
        {           
        }

        public MongoConnection(string leftServer, int leftPort, string rightServer, int rightPort, bool slaveOk)
        {
            this.LeftServer = leftServer;
            this.LeftPort = leftPort;
            this.RightServer = rightServer;
            this.RightPort = rightPort;
            this.SlaveOk = slaveOk;
        }

        public DateTime TimeCreated { get; set; }
        public string LeftServer { get; set; }
        public int LeftPort { get; set; }
        public string RightServer { get; set; }
        public int RightPort { get; set; }
        public bool SlaveOk { get; set; }

        public void ReturnToPool()
        {
            MongoConnectionPool.AddConnection(this, true);
        }

    }
}
