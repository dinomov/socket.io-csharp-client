namespace SocketIOClient
{
   public enum PacketType
   {
      Disconnect,
      Connect,
      Heartbeat,
      Message,
      Json,
      Event,
      Ack,
      Error,
      NoOp
   }
}