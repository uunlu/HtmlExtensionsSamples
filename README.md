# Html Extensions Samples
<b>Asp.NET MVC Html Extensions Samples</b>

<h4>Why To Use Html Extensions?</h4>
<ul>
 Using modular and re-useable code always takes a lot of overhead over shoulders. By extending existing MVC Helper classes following benefits can be achieved: 
 <li> Simplify Html Code
 <li> Combine several lines of Html in a single Helper
 <li> Create clean code on view
</ul>

---------------------------
<h4>-> Go to Components Folder</h4>
You can see Html Helper method samples in this folder. 

<h4>-> HtmlExtensionsImage: </h4>

Usage Example: 
<br/>
Helper.Image("imagelink", "alt", new { class ="img-responsive" } )
<br/>
<br/>
There are different overload methods available. 

<h4>-> HtmlExtensionsButton: </h4>

Custom bootstrap button helper extensions.

<h4>-> HtmlExtensionsTextBox: </h4>

Custom bootstrap textbox and form field helper extensions.

Usage Example: 
<br/>
@Html.FormFieldTextBoxFor(x => x.Team, HtmlExtensions.HmlExtensionsCommon.InputTypes.text, new { @class = "form-control" })

<b>FormFieldTextBoxFor </b> adds TextBox with Label in Bootstrap style.
Label value is read from expression property name or Custom Data Attribute if exists. 

<h4>-> HtmlExtensionsCheckBox: </h4>

Custom bootstrap style checkbox extensions.

<h4>-> HtmlExtensionsImageBox: </h4>

Bootstrap customizable image box. 

Usage Example:
<br/>
@Html.ImageBoxFor(x => x.Image, "", "logo-barca", true, HmlExtensionsCommon.ImageTypes.roundedCorners, new { @title="Barcelona City"})
