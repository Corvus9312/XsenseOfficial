using System.Globalization;

namespace XsenseOfficial.Components.Pages;

public class JoinUsBase : CusComponentBase
{
    protected string HeadImageUrl => $"/images/joinUs/joinUsHead.{CultureInfo.CurrentCulture.Name}.png";

    protected string TrainingImageUrl => $"/images/joinUs/PersonnelTraining.{CultureInfo.CurrentCulture.Name}.png";
}
