# Implementaion Of Search Methode

```csharp
public RBNode Find(int value)
{
return Find(Root, value);
}

private RBNode Find(RBNode StratNode, int value)
{
if (StratNode == null || StratNode.Value == value)
return StratNode;

     if (value > StratNode.Value)
         return Find(StratNode.Right,value);
     else
         return Find(StratNode.Left, value);

}
```
