﻿//  Copyright (c) RXD Solutions. All rights reserved.
//  FusionLink is licensed under the MIT license. See LICENSE.txt for details.

using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using sophis.portfolio;
using sophis.utils;
using static RxdSolutions.FusionLink.ExcelHelper;
using static RxdSolutions.FusionLink.PortfolioViewHelper;

namespace RxdSolutions.FusionLink
{
    public class CopyCellAsRTDFunctionToClipboard : CSMPositionCtxMenu
    {
        public override bool IsFolioAuthorized(ArrayList folioVector)
        {
            var selectedColumn = GetSelectedColumn();

            return !string.IsNullOrWhiteSpace(selectedColumn);
        }

        public override bool IsAuthorized(ArrayList positionList)
        {
            var selectedColumn = GetSelectedColumn();

            return !string.IsNullOrWhiteSpace(selectedColumn);
        }

        public override int GetContextMenuGroup()
        {
            return 101;
        }

        public override void FolioAction(ArrayList folioVector, CMString ActionName)
        {
            try
            {
                var sb = new StringBuilder();

                for (int i = 0; i < folioVector.Count; i++)
                {
                    var folio = folioVector[i] as CSMPortfolio;

                    string formula = GetPortfolioFormula(folio.GetCode(), GetSelectedColumn());
                    sb.Append(formula).AppendLine();
                }

                Clipboard.SetText(sb.ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "FusionLink");
            }
        }

        public override void Action(ArrayList positionList, CMString ActionName)
        {
            try
            {
                var sb = new StringBuilder();

                for (int i = 0; i < positionList.Count; i++)
                {
                    //Check if the position is a future. If so, allow it
                    var position = positionList[i] as CSMPosition;

                    string formula = GetPositionFormula(position.GetIdentifier(), GetSelectedColumn());
                    sb.Append(formula).AppendLine();
                }

                Clipboard.SetText(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "FusionLink");
            }
        }
    }
}