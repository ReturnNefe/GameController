## v0.1.3

**TODO**
1. Use ``XML`` to define UI layout.
2. Try to supply ``Visual Joystick``.
3. Use ``Ant Design for Blazor`` to add ``Sliders``.

**Tips**

* Use ``DynamicComponent`` to render component dynamically.
* Custom component can be used in ``@foreach`` block. [1]
* Custom component can use inline-string. [2]


[1] Code:

```csharp
@foreach {
    <CustomComponent />
}
```

[2] Code:

```csharp
<CustomComponent CssClass=@(DateTime.Now.ToString())/>
```


**Done**
1. Disable ``Double-Click`` to zoom completely.