# DialectSoftware.Encoding
Generic implementation for arbitrary encoding schemes

```C#
var encoder = new DialectSoftware.Encoding.BaseNEncoder(26, "0123456789abcdefghijklmnop".ToArray());
foreach (var e in encoder)
{
    Console.WriteLine("{0} {1}", e, encoder.Decode(e));
}

var encoder = new DialectSoftware.Encoding.BaseNRotaryEncoder(26, "abcdefghijklmnopqrstuvwxyz".ToArray());
foreach (var e in encoder)
{
    Console.WriteLine("{0} {1}", e, encoder.Decode(e));
}

var encoder = new DialectSoftware.Encoding.BaseNEncoder(2, "01".ToArray());
foreach (var e in encoder)
{
    Console.WriteLine("{0} {1}", e, encoder.Decode(e));
}
