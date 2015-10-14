﻿using MyvarCraft.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyvarCraft.Networking.Packets
{
    public class Response : Packet
    {
        public string Json { get; set; }

        public Response()
        {
            ID = 0;
        }

        public override void Write(NetworkStream ns)
        {
            MinecraftStream read = new MinecraftStream();
            read.WriteString(Json);
            var buf = read.Flush(ID);
            ns.Write(buf, 0, buf.Length);
        }

    }
}
