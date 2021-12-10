﻿/*  ResultsDlg.cs
 *   
 *  Copyright © 2020 Wacom Co.,Ltd.
 */
using System.Windows.Forms;
using GsvClient.Models;

namespace WacomInkVerificationSample
{
    /// <summary>
    /// Displays the results of a SignatureEngine.VerifySignature call
    /// </summary>
    public partial class ResultsDlg : Form
    {
        string _reason;

        public ResultsDlg(VerificationResult result)
        {
            InitializeComponent();

            txtScore.Text = result.Score.ToString();
            txtEngine.Text = result.Engine.ToString();
            txtInconsistency.Text = result.Inconsistency.ToString();
            txtComplexity.Text = result.Complexity.ToString();
            txtMixedScore.Text = result.MixedScore.ToString();

            var status = result.State;

            txtEnrollSizeDyn.Text = status.DynamicStatus.EnrollmentSize.ToString();
            txtEnrollStateDyn.Text = status.DynamicStatus.EnrollmentState.ToString();
            txtNumSigsDyn.Text = status.DynamicStatus.NumSignatures.ToString();

            txtEnrollSizeStat.Text = status.StaticStatus.EnrollmentSize.ToString();
            txtEnrollStateStat.Text = status.StaticStatus.EnrollmentState.ToString();
            txtNumSigsStat.Text = status.StaticStatus.NumSignatures.ToString();

            _reason = result.Reason.Replace("\n","\r\n");
            buttonReason.Enabled = (_reason != null && _reason.Length != 0);
        }

        private void buttonReason_Click(object sender, System.EventArgs e)
        {
            var resultsReasonDlg = new ResultsReasonDlg(_reason);
            resultsReasonDlg.ShowDialog(this);
        }
    }
}
