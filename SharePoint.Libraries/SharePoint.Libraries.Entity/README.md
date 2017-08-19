
<html>

<head>
<meta http-equiv=Content-Type content="text/html; charset=Windows-1254">
<meta name=Generator content="Microsoft Word 15 (filtered)">
<style>
<!--
 /* Font Definitions */
 @font-face
	{font-family:"Cambria Math";
	panose-1:2 4 5 3 5 4 6 3 2 4;}
@font-face
	{font-family:Calibri;
	panose-1:2 15 5 2 2 2 4 3 2 4;}
@font-face
	{font-family:Consolas;
	panose-1:2 11 6 9 2 2 4 3 2 4;}
 /* Style Definitions */
 p.MsoNormal, li.MsoNormal, div.MsoNormal
	{margin-top:0cm;
	margin-right:0cm;
	margin-bottom:8.0pt;
	margin-left:0cm;
	line-height:107%;
	font-size:11.0pt;
	font-family:"Calibri",sans-serif;}
a:link, span.MsoHyperlink
	{color:blue;
	text-decoration:underline;}
a:visited, span.MsoHyperlinkFollowed
	{color:#954F72;
	text-decoration:underline;}
p
	{margin-right:0cm;
	margin-left:0cm;
	font-size:12.0pt;
	font-family:"Times New Roman",serif;}
.MsoChpDefault
	{font-family:"Calibri",sans-serif;}
.MsoPapDefault
	{margin-bottom:8.0pt;
	line-height:107%;}
@page WordSection1
	{size:595.3pt 841.9pt;
	margin:70.85pt 70.85pt 70.85pt 70.85pt;}
div.WordSection1
	{page:WordSection1;}
-->
</style>

</head>

<body lang=TR link=blue vlink="#954F72">

<div class=WordSection1>

<p class=MsoNormal><b><span style='font-size:14.0pt;line-height:107%'>SPLibraries
Entity (SharePoint.Libraries.Entity)</span></b></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>This mapper can be easily implemented to a Project by
defining entity and repository classes. I helps converting list item to your
custom entity or vice versa.</p>

<p class=MsoNormal>By using repository base classes you will get basic methods
without any coding and because of the perfomance concern it will add view
fields to your query according to the entity properties unless otherwise
specified.</p>

<p class=MsoNormal>It supports all most common SharePoint fields including
publishing and taxonomy fields.</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal><b><span style='font-size:12.0pt;line-height:107%'>Entities</span></b></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>You need to derive you custom entity from EntityBase class.
By doing that you will get basic SP fields such as ID, CreatedBy, Modified.</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>#region</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Assembly SharePoint.Libraries.Entity, Version=1.0.0.0,
Culture=neutral, PublicKeyToken=0be90ed3695f8b28</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:green'>//
C:\Users\sa_spadmin\Source\Repos\SPLibraries\SharePoint.Libraries\packages\SharePoint.Libraries.Entity.1.0.2\lib\net452\SharePoint.Libraries.Entity.dll</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>#endregion</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span lang=EN-US style='font-size:9.5pt;font-family:
Consolas;color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span lang=EN-US style='font-size:9.5pt;font-family:
Consolas;color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> System;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> System.Collections.Generic;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Microsoft.SharePoint;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>namespace</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePoint.Libraries.Entity</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>{</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>class</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>EntityBase</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> : </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>IEntity</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> EntityBase();</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>(Name = </span><span style='font-size:9.5pt;font-family:Consolas;
color:#A31515'>&quot;ID&quot;</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'>, RestrictUpdate = </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>true</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>)]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>int</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Id { </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>get</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>set</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>(Name = </span><span style='font-size:9.5pt;font-family:Consolas;
color:#A31515'>&quot;Title&quot;</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'>)]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>string</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Title { </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>get</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>set</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>DateTime</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Created { </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>get</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>set</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>DateTime</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Modified { </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>get</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>set</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>(Name = </span><span style='font-size:9.5pt;font-family:Consolas;
color:#A31515'>&quot;Editor&quot;</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>)]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldUserValue</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'> ModifiedBy { </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>get</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>set</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>(Name = </span><span style='font-size:9.5pt;font-family:Consolas;
color:#A31515'>&quot;Author&quot;</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>)]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldUserValue</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'> CreatedBy { </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>get</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>set</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>List</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&lt;</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>IAttachmentEntity</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'>&gt; Attachments { </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>get</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>set</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    }</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>}</span></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>This is a sample entity, you can see the description of
properties. I tried to add all frequently used fields. </p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Microsoft.SharePoint;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Microsoft.SharePoint.Taxonomy;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePoint.Libraries.Entity;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> System;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>namespace</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Entities</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>{</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>class</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>CustomTestEntity</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'> : </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>EntityBase</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>string</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> ChoiceField { </span><span style='font-size:9.5pt;font-family:
Consolas;color:blue'>get</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>set</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>int</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> NumberField { </span><span style='font-size:9.5pt;font-family:
Consolas;color:blue'>get</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>set</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> can be givven a different name rather than sp field's internal
name</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;/summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>(Name = </span><span style='font-size:9.5pt;font-family:Consolas;
color:#A31515'>&quot;CurrencyField&quot;</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>)]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>double</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Currency { </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>get</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>set</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> This field won't be updated when AddUpdateItem method executed.</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;/summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>(RestrictUpdate = </span><span style='font-size:9.5pt;font-family:
Consolas;color:blue'>true</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>)]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>DateTime</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>? DateTimeField { </span><span style='font-size:9.5pt;font-family:
Consolas;color:blue'>get</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>set</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>(Name = </span><span style='font-size:9.5pt;font-family:Consolas;
color:#A31515'>&quot;YesNoField&quot;</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>)]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>bool</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> BooleanField { </span><span style='font-size:9.5pt;font-family:
Consolas;color:blue'>get</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>set</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldUserValue</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'> PersonField { </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>get</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>set</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldUrlValue</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'> HyperlinkField { </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>get</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>set</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> for multiple fields use 'TaxonomyFieldValueCollection'</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;/summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>TaxonomyFieldValue</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> MetadataField { </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>get</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>; </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>set</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldLookupValue</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> LookupSingleField { </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>get</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>; </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>set</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldLookupValueCollection</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> LookupMultiField { </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>get</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>; </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>set</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>string</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> PublishingPageContent { </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>get</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>set</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        [</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPFieldFlag</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>]</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>DateTime</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>? PublishingStartDate { </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>get</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>set</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> This property won't be mapped because of lack of the SPFieldFlag
attribute. It is for only internal use.</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;/summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>string</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> InternalProperty { </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>get</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>set</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>; }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    }</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>}</span></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>If you want to work document libraries, your entity should
be derived from DocumentBase class</p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePoint.Libraries.Entity;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>namespace</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Entities</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>{</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>class</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>LibraryEntity</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'> : </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>DocumentBase</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:green'>//Custom fields</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    }</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>}</span></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal><b>Repositories</b></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePoint.Libraries.Entity;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Entities;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Microsoft.SharePoint;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> System.Collections.Generic;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>namespace</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Repositories</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>{</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>class</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>CustomTestEntityRepository</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> : </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>RepositoryBase</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>&lt;</span><span
style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>CustomTestEntity</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>protected</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>override</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>string</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> ListUrl =&gt; </span><span style='font-size:9.5pt;font-family:
Consolas;color:#A31515'>&quot;Lists/CustomTestList&quot;</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> CustomTestEntityRepository(</span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>SPWeb</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> web) : </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>base</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>(web)</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> You can easily pass your custom query to the base GetItems
method. If you don't specify any view field, base repository is going to add
view fields according to your entity.</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> You don't need any custom method for Add/Update/Delete item, get
allitems, getitembyId operations.</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;/summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;returns&gt;&lt;/returns&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>IList</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&lt;</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>CustomTestEntity</span><span style='font-size:9.5pt;font-family:
Consolas;color:black'>&gt; GetItemsByOrder()</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>            </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPQuery</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> orderQuery = </span><span style='font-size:9.5pt;font-family:
Consolas;color:blue'>new</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPQuery</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>();</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>            orderQuery.Query = </span><span style='font-size:9.5pt;
font-family:Consolas;color:#A31515'>&quot;&lt;OrderBy&gt;&lt;FieldRef
Name='DateTimeField' /&gt;&lt;/OrderBy&gt;&quot;</span><span style='font-size:
9.5pt;font-family:Consolas;color:black'>;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>            </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>return</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>base</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>.GetItems(orderQuery);</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    }</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>}</span></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePoint.Libraries.Entity;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Microsoft.SharePoint;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>namespace</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Repositories</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>{</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> If you want to work with list items, use SPRepositoryBase </span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;/summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>class</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>CustomTestSPRepository</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> : </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>SPRepositoryBase</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>protected</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>override</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>string</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> ListUrl =&gt; </span><span style='font-size:9.5pt;font-family:
Consolas;color:#A31515'>&quot;Lists/CustomTestList&quot;</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> CustomTestSPRepository(</span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>SPWeb</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> web) : </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>base</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>(web)</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPListItemCollection</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> GetItemsByOrder()</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>            </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPQuery</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> orderQuery = </span><span style='font-size:9.5pt;font-family:
Consolas;color:blue'>new</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPQuery</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>();</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>            orderQuery.Query = </span><span style='font-size:9.5pt;
font-family:Consolas;color:#A31515'>&quot;&lt;OrderBy&gt;&lt;FieldRef
Name='DateTimeField' /&gt;&lt;/OrderBy&gt;&quot;</span><span style='font-size:
9.5pt;font-family:Consolas;color:black'>;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>            </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>return</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>base</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>.GetItems(orderQuery);</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    }</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>}</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>&nbsp;</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePoint.Libraries.Entity;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Entities;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Microsoft.SharePoint;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>namespace</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Repositories</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>{</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> This repository is being used for quering by 'SPSiteDataQuery'</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>///</span><span style='font-size:9.5pt;font-family:Consolas;
color:green'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:gray'>&lt;/summary&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>class</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>CustomTestEntitySiteRepository</span><span style='font-size:
9.5pt;font-family:Consolas;color:black'> : </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>SiteRepositoryBase</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>&lt;</span><span
style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>CustomTestEntity</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> CustomTestEntitySiteRepository(</span><span style='font-size:
9.5pt;font-family:Consolas;color:#2B91AF'>SPWeb</span><span style='font-size:
9.5pt;font-family:Consolas;color:black'> web) : </span><span style='font-size:
9.5pt;font-family:Consolas;color:blue'>base</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>(web)</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    }</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>}</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>&nbsp;</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePoint.Libraries.Entity;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Microsoft.SharePoint;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Entities;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>namespace</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Repositories</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>{</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>class</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>ImagesLibraryRepository</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> : </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>RepositoryBase</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>&lt;</span><span
style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>LibraryEntity</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>&gt;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>protected</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>override</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>string</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> ListUrl =&gt; </span><span style='font-size:9.5pt;font-family:
Consolas;color:#A31515'>&quot;PublishingImages&quot;</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>public</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> ImagesLibraryRepository(</span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>SPWeb</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> web) : </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>base</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>(web)</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    }</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>}</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>&nbsp;</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>&nbsp;</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>&nbsp;</span></p>

<p class=MsoNormal><img width=604 height=165 id="Resim 1"
src="SPLibraries%20Entity_dosyalar/image001.jpg"></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal><img width=356 height=180 id="Resim 2"
src="SPLibraries%20Entity_dosyalar/image002.jpg"></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal><img width=604 height=297 id="Resim 3"
src="SPLibraries%20Entity_dosyalar/image003.jpg"></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal><img width=605 height=302 id="Resim 5"
src="SPLibraries%20Entity_dosyalar/image004.jpg"></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal><img width=604 height=296 id="Resim 6"
src="SPLibraries%20Entity_dosyalar/image005.jpg"></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal><img width=335 height=220 id="Resim 8"
src="SPLibraries%20Entity_dosyalar/image006.jpg"></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal><img width=604 height=209 id="Resim 9"
src="SPLibraries%20Entity_dosyalar/image007.jpg"></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Microsoft.SharePoint;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Entities;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole.Repositories;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> System.Collections.Generic;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>namespace</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> SharePointTestConsole</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>{</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>class</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>Program</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>static</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>void</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> Main(</span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>string</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>[] args)</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>            </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> (</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPSite</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> site = </span><span style='font-size:9.5pt;font-family:Consolas;
color:blue'>new</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> </span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPSite</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'>(</span><span style='font-size:9.5pt;font-family:Consolas;
color:#A31515'>&quot;http://dev.sp2016&quot;</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>))</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>            {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                </span><span style='font-size:9.5pt;font-family:
Consolas;color:blue'>using</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> (</span><span style='font-size:9.5pt;font-family:Consolas;
color:#2B91AF'>SPWeb</span><span style='font-size:9.5pt;font-family:Consolas;
color:black'> web = site.RootWeb)</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                {</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>CustomTestEntityRepository</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> listRep = </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>new</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> </span><span
style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>CustomTestEntityRepository</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>(web);</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:blue'>var</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'> orderedItems = listRep.GetItemsByOrder();</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>CustomTestSPRepository</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> spRep = </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>new</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> </span><span
style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>CustomTestSPRepository</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>(web);</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>SPListItemCollection</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> spItems =
spRep.GetItemsByOrder();</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:green'>// Can be used for any library such as Pages</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>ImagesLibraryRepository</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> libraryRep = </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>new</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> </span><span
style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>ImagesLibraryRepository</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>(web);</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>IList</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>&lt;</span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>LibraryEntity</span><span style='font-size:
9.5pt;font-family:Consolas;color:black'>&gt; imagesDocs =
libraryRep.GetItems();</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:green'>// You can easily update a document to a
library or attach to a list item.</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    libraryRep.AddDocument(</span><span
style='font-size:9.5pt;font-family:Consolas;color:#A31515'>&quot;NewFolder/Image&quot;</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>, </span><span
style='font-size:9.5pt;font-family:Consolas;color:#A31515'>&quot;UploadFilePath.jpg&quot;</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>);</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:green'>// You can't get all SP fields via
SPSiteDataQuery!</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>SPSiteDataQuery</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> dataQuery = </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>new</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> </span><span
style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>SPSiteDataQuery</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>();</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    dataQuery.Webs = </span><span
style='font-size:9.5pt;font-family:Consolas;color:#A31515'>&quot;&lt;Webs
Scope=\&quot;Recursive\&quot;&gt;&quot;</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    dataQuery.Lists = </span><span
style='font-size:9.5pt;font-family:Consolas;color:#A31515'>&quot;&lt;Lists
ServerTemplate=\&quot;100\&quot; /&gt;&quot;</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    dataQuery.ViewFields = </span><span
style='font-size:9.5pt;font-family:Consolas;color:#A31515'>&quot;&lt;FieldRef
Name=\&quot;Title\&quot; /&gt;&lt;FieldRef Name=\&quot;ID\&quot;
/&gt;&lt;FieldRef Name=\&quot;NumberField\&quot; /&gt;&lt;FieldRef
Name=\&quot;NumberField\&quot; /&gt;&lt;FieldRef
Name=\&quot;DateTimeField\&quot; /&gt;&quot;</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    dataQuery.Query = </span><span
style='font-size:9.5pt;font-family:Consolas;color:#A31515'>&quot;&lt;Where&gt;&lt;Eq&gt;&lt;FieldRef
Name=\&quot;Title\&quot;/&gt;&lt;Value Type='Text'&gt;Test item 1
title&lt;/Value&gt;&lt;/Eq&gt;&lt;/Where&gt;&quot;</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>&nbsp;</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>CustomTestEntitySiteRepository</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> siteRep = </span><span
style='font-size:9.5pt;font-family:Consolas;color:blue'>new</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'> </span><span
style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>CustomTestEntitySiteRepository</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>(web);</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                    </span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>IList</span><span style='font-size:9.5pt;
font-family:Consolas;color:black'>&lt;</span><span style='font-size:9.5pt;
font-family:Consolas;color:#2B91AF'>CustomTestEntity</span><span
style='font-size:9.5pt;font-family:Consolas;color:black'>&gt; dataResult =
siteRep.GetItems(dataQuery);</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>                }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>            }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>        }</span></p>

<p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
normal;text-autospace:none'><span style='font-size:9.5pt;font-family:Consolas;
color:black'>    }</span></p>

<p class=MsoNormal><span style='font-size:9.5pt;line-height:107%;font-family:
Consolas;color:black'>}</span></p>

<p class=MsoNormal>&nbsp;</p>

<p class=MsoNormal><b>RepositoryBase Public Members</b></p>

<table class=MsoTableGrid border=1 cellspacing=0 cellpadding=0
 style='border-collapse:collapse;border:none'>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>GetItemById(</span><span
  style='font-size:9.5pt;font-family:Consolas;color:blue'>int</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> id)</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>GetItems()</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>GetItems(</span><span
  style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>SPQuery</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> query)</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>GetAllItems()</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>GetItemsAndPosition(</span><span
  style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>SPQuery</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> spQuery, </span><span
  style='font-size:9.5pt;font-family:Consolas;color:blue'>out</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> </span><span
  style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>SPListItemCollectionPosition</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> position)</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>ConvertToEntity(</span><span
  style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>SPListItem</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> item)</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>AddUpdateItem(</span><span
  style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>T</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> entity)</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>SystemUpdateItem(</span><span
  style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>T</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> entity, </span><span
  style='font-size:9.5pt;font-family:Consolas;color:blue'>bool</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'>
  incrementListItemVersion)</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>AddDocument(</span><span
  style='font-size:9.5pt;font-family:Consolas;color:blue'>string</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> folderUrl, </span><span
  style='font-size:9.5pt;font-family:Consolas;color:blue'>string</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> filePath)</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:#2B91AF'>SPFolder</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> GetFolder(</span><span
  style='font-size:9.5pt;font-family:Consolas;color:blue'>string</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> folderUrl)</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>DeleteItem(</span><span
  style='font-size:9.5pt;font-family:Consolas;color:blue'>int</span><span
  style='font-size:9.5pt;font-family:Consolas;color:black'> Id)</span></p>
  </td>
 </tr>
 <tr>
  <td width=604 valign=top style='width:453.1pt;border:solid windowtext 1.0pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='margin-bottom:0cm;margin-bottom:.0001pt;line-height:
  normal'><span style='font-size:9.5pt;font-family:Consolas;color:black'>List</span></p>
  </td>
 </tr>
</table>

<p class=MsoNormal><b>&nbsp;</b></p>

<p class=MsoNormal>&nbsp;</p>

</div>

</body>

</html>
