using System;
using System.Collections.Generic;
using System.Text;

namespace SMAH1.Forms.Text.Persian
{
    internal enum DateConcept
    {
        [SMAH1.Attributes.Descriptions("خالی")]
        None,

        [SMAH1.Attributes.Descriptions("سال آینده")]
        FutureYear,

        [SMAH1.Attributes.Descriptions("ماه آینده")]
        FutureMonth,

        [SMAH1.Attributes.Descriptions("هفته‌ی آینده")]
        FutureWeek,

        [SMAH1.Attributes.Descriptions("فردا")]
        Tomorrow,

        [SMAH1.Attributes.Descriptions("امروز")]
        Today,

        [SMAH1.Attributes.Descriptions("دیروز")]
        Yesterday,

        [SMAH1.Attributes.Descriptions("هفته‌ی گذشته")]
        LastWeek,

        [SMAH1.Attributes.Descriptions("ماه گذشته")]
        LastMonth,

        [SMAH1.Attributes.Descriptions("پارسال")]
        LastYear
    };
}
