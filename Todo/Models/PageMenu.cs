using System;
using System.Collections.Generic;

#nullable disable

namespace Todo.Models
{
    public partial class PageMenu
    {
        public string PageMenuId { get; set; }
        public string PageMenuPid { get; set; }
        public string PageMenuNo { get; set; }
        public string PageMenuNm { get; set; }
        public string PageMenuPrtc { get; set; }
        public string PageMenuSsvr { get; set; }
        public string PageUriId { get; set; }
        public string PageMenuArg { get; set; }
        public string PageMenuPic { get; set; }
        public string PageMenuNtyp { get; set; }
        public char PageMenuEnd { get; set; }
        public decimal PageMenuLvl { get; set; }
        public char PageMenuStat { get; set; }
        public string PageMenuNoa { get; set; }
        public string PageMenuIda { get; set; }
        public string PageMenuNma { get; set; }
        public string PageMenuMemo { get; set; }
        public string UpdateUser { get; set; }
        public decimal? UpdateTime { get; set; }
        public char PageMenuHp { get; set; }
        public decimal? PageMenuSort { get; set; }
        public string ApName { get; set; }
        public char IsAllowDeploy { get; set; }
        public char IsPassDeploy { get; set; }
        public char IsAllowModify { get; set; }
        public char PageMenuShow { get; set; }

        public virtual PageUri PageUri { get; set; }
    }
}
