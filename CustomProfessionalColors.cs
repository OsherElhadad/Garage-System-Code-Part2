using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class CustomProfessionalColors : ProfessionalColorTable
{
    public Color MenuBackColor = ColorTranslator.FromHtml("#6464FA");
    public Color HoverMenuColor = ColorTranslator.FromHtml("#6464EA");
    public Color HoverToolColor = ColorTranslator.FromHtml("#9999FA");

    public CustomProfessionalColors()
    {

    }

    public CustomProfessionalColors(Color MenuBackColor1, Color HoverMenuColor1, Color HoverToolColor1)
    {
        this.MenuBackColor = MenuBackColor1;
        this.HoverToolColor = HoverToolColor1;
        this.HoverMenuColor = HoverMenuColor1;
    }



    public override Color ToolStripGradientBegin

    { get { return MenuBackColor; } }




    public override Color ToolStripGradientMiddle

    { get { return MenuBackColor; } }




    public override Color ToolStripGradientEnd

    { get { return MenuBackColor; } }




    public override Color MenuStripGradientBegin

    { get { return MenuBackColor; } }




    public override Color MenuStripGradientEnd

    { get { return MenuBackColor; } }




    public override Color ToolStripDropDownBackground

    { get { return HoverMenuColor; } }




    public override Color MenuItemSelected

    { get { return HoverToolColor; } }




    public override Color MenuItemSelectedGradientBegin

    { get { return HoverMenuColor; } }




    public override Color MenuItemSelectedGradientEnd

    { get { return HoverMenuColor; } }




    public override Color ButtonCheckedGradientBegin

    { get { return HoverMenuColor; } }




    public override Color ButtonCheckedGradientEnd

    { get { return HoverMenuColor; } }




    public override Color ButtonCheckedGradientMiddle

    { get { return HoverMenuColor; } }




    public override Color ButtonCheckedHighlight

    { get { return HoverMenuColor; } }




    public override Color ButtonCheckedHighlightBorder

    { get { return Color.Black; } }




    public override Color ButtonPressedBorder

    { get { return HoverMenuColor; } }




    public override Color ButtonPressedGradientBegin

    { get { return HoverMenuColor; } }




    public override Color ButtonPressedGradientEnd

    { get { return HoverMenuColor; } }




    public override Color ButtonPressedGradientMiddle

    { get { return HoverMenuColor; } }




    public override Color ButtonPressedHighlight

    { get { return HoverMenuColor; } }




    public override Color ButtonPressedHighlightBorder

    { get { return HoverMenuColor; } }




    public override Color ButtonSelectedBorder

    { get { return HoverMenuColor; } }




    public override Color ButtonSelectedGradientBegin

    { get { return HoverMenuColor; } }




    public override Color ButtonSelectedGradientEnd

    { get { return HoverMenuColor; } }




    public override Color ButtonSelectedGradientMiddle

    { get { return HoverMenuColor; } }




    public override Color ButtonSelectedHighlight

    { get { return HoverMenuColor; } }




    public override Color ButtonSelectedHighlightBorder

    { get { return HoverMenuColor; } }




    public override Color CheckBackground

    { get { return HoverMenuColor; } }




    public override Color CheckPressedBackground

    { get { return HoverMenuColor; } }




    public override Color CheckSelectedBackground

    { get { return Color.Black; } }




    public override Color GripDark

    { get { return HoverMenuColor; } }




    public override Color GripLight

    { get { return HoverMenuColor; } }




    public override Color ImageMarginGradientBegin

    { get { return HoverMenuColor; } }




    public override Color ImageMarginGradientEnd

    { get { return HoverMenuColor; } }




    public override Color ImageMarginGradientMiddle

    { get { return HoverMenuColor; } }




    public override Color ImageMarginRevealedGradientBegin

    { get { return HoverMenuColor; } }




    public override Color ImageMarginRevealedGradientEnd

    { get { return HoverMenuColor; } }




    public override Color ImageMarginRevealedGradientMiddle

    { get { return HoverMenuColor; } }




    public override Color MenuBorder

    { get { return Color.Black; } }




    public override Color MenuItemBorder

    { get { return HoverToolColor; } }




    public override Color MenuItemPressedGradientBegin

    { get { return HoverMenuColor; } }




    public override Color MenuItemPressedGradientEnd

    { get { return HoverMenuColor; } }




    public override Color MenuItemPressedGradientMiddle

    { get { return HoverMenuColor; } }

}
