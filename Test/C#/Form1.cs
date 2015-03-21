
using HaarCascadeClassifer;
using System.Windows.Forms;
using System;
using System.Xml;
using System.Drawing;

namespace HaarCascadeClassifierTEST
{
    public partial class Form1 : Form
    {
        //--------------------------------------------------------------------------
        // HaarCascadeClassifierTEST > Form1.cs
        //--------------------------------------------------------------------------
        // Huseyin Atasoy
        // huseyin@atasoyweb.net
        // www.atasoyweb.net
        // July 2012
        //--------------------------------------------------------------------------
        // Copyright 2012 Huseyin Atasoy
        //
        // Licensed under the Apache License, Version 2.0 (the "License");
        // you may not use this file except in compliance with the License.
        // You may obtain a copy of the License at
        //
        //     http://www.apache.org/licenses/LICENSE-2.0
        //
        // Unless required by applicable law or agreed to in writing, software
        // distributed under the License is distributed on an "AS IS" BASIS,
        // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
        // See the License for the specific language governing permissions and
        // limitations under the License.
        //--------------------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap selectedBitmap;
        private HaarDetector detector;

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            XmlDocument xmlDoc=new XmlDocument();
            xmlDoc.LoadXml(HaarCascadeClassifer.My.Resources.Resources.haarcascade_frontalface_alt);
            detector = new HaarDetector(xmlDoc);
            lblInfo.Text = "XML cascade parsed in " + Math.Round((DateTime.Now - start).TotalMilliseconds, 3).ToString() + " milliseconds.";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFDialog = new OpenFileDialog();
            try
            {
                oFDialog.Filter = "Images|*.tiff;*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                oFDialog.FilterIndex = 0;
                oFDialog.FileName = "";
                if (oFDialog.ShowDialog() != DialogResult.OK) return;
            }
            catch(Exception ex) { return; }

            selectedBitmap = new Bitmap(oFDialog.FileName);
            pictureBox1.Image = (Image)selectedBitmap.Clone();

            btnDetect.Enabled = true;
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            int maxDetCount = Int32.MaxValue;
            int minNRectCount = (int)nudMinNRectCount.Value;
            float firstScale = detector.Size2Scale((int)nudMinSize.Value);
            float maxScale = detector.Size2Scale((int)nudMaxSize.Value);
            float scaleMult = (float)nudScaleMult.Value;
            float sizeMultForNesRectCon = (float)nudSizeMultForNesRectCon.Value;
            float slidingRatio = (float)nudSlidingRatio.Value;
            Pen pen = new Pen(Brushes.Red, (int)nudLineWidth.Value);
            HaarCascadeClassifer.HaarDetector.DetectionParams detectorParameters;
            detectorParameters = new HaarCascadeClassifer.HaarDetector.DetectionParams(maxDetCount, minNRectCount, firstScale, maxScale, scaleMult, sizeMultForNesRectCon, slidingRatio, pen);

            Bitmap bmp = (Bitmap)selectedBitmap.Clone();

            DateTime start = DateTime.Now;
            HaarCascadeClassifer.HaarDetector.DResults results = detector.Detect(ref bmp, detectorParameters);
            TimeSpan Elapsed = DateTime.Now - start;

            pictureBox1.Image = bmp;
            lblInfo.Text = results.SearchedSubRegionCount.ToString() + " subregions were searched and " + results.NOfObjects.ToString() + " object(s) were detected in " + Math.Round(Elapsed.TotalMilliseconds, 3).ToString() + " milliseconds.";
        }

    }
}
