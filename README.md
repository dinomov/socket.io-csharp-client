# C# Socket.IO client
A simple C# implementation of the Socket.IO client using [WebSocket4Net](http://websocket4net.codeplex.com/).

*DISCLAIMER: This is not a complete implementation of the Socket.IO client. There are lots of missing parts. Please feel free to submit a pull-request to add whatever feature is missing that you need.*

## Usage

#### Server

```JavaScript
var io = require("socket.io").listen(3000);

io.sockets.on("connection", function (socket) {
   socket.on("data", function (data) {
      console.log("Client sent: " + data);
      
      if (data) {
         socket.emit("data", data.toUpperCase(), { length: data.length });
      }
   });
});
```

Start the server by running ```npm install``` then ```node index.js``` from the ```Example/Server``` directory.

#### Client

```CSharp
using System;
using SocketIO.Client;

namespace SimpleClient
{   
   class Example
   {
      static void Main()
      {
         var io = new SocketIOClient();
         
         var socket = io.Connect("http://localhost:3000/");

         socket.On("data", (args, callback) =>
         {
            Console.WriteLine("Server sent:");

            for (int i = 0; i < args.Length; i++)
            {
               Console.WriteLine("[" + i + "] => " + args[i]);
            }
         });
         
         string line;
         
         while ((line = Console.ReadLine()) != "q")
         {
            socket.Emit("data", line);
         }
      }
   }
}
```

Run the C# client and interact with the server by typing anything into the console.