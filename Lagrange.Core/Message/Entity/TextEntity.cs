using Lagrange.Core.Internal.Packets.Message.Element;
using Lagrange.Core.Internal.Packets.Message.Element.Implementation;

namespace Lagrange.Core.Message.Entity;

[MessageElement(typeof(Text))]
public class TextEntity : IMessageEntity
{
    public string Text { get; set; }
    
    public TextEntity() => Text = "";
    
    public TextEntity(string text) => Text = text;

    IEnumerable<Elem> IMessageEntity.PackElement()
    {
        return new Elem[] // explicit interface implementation
        {
            new() { Text = new Text { Str = Text, } }
        };
    }
    
    IMessageEntity? IMessageEntity.UnpackElement(Elem elems) => 
        elems.Text is { Str: not null, Attr6Buf: null } text ? new TextEntity(text.Str) : null;

    public string ToPreviewString()
    {
        return $"[Text]: {Text}";
    }
}