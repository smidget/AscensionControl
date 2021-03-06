﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace AscensionControl
{
    public partial class MainInterface : Form
    {
        public Study currentStudy;
        public Subject currentSubject;
        public Session currentSession;
        public Trial currentTrial;
        Recorder recorder;
        public TrackerInterface trackerinterface;
        public List<bool> blankList;
        public DatabaseControl database;
        public static int caps_switch;
        public static Exporter exporter = new Exporter();
        BackgroundWorker bw = new BackgroundWorker();
                

        public MainInterface()
        {
            InitializeComponent();
            database = new DatabaseControl();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;

            blankList = new List<bool>();

            //studies = database.Load();
            currentStudy = new Study();
            studyDisplay.DataSource = database.GetStudies();

            currentSubject = new Subject();
            //subjectDisplay.DataSource = currentStudy.subjects;

            currentSession = new Session();
            //sessionDisplay.DataSource = currentSubject.sessions;

            currentTrial = new Trial();
            //trialDisplay.DataSource = currentSession.trials;

            radiusSettings.SelectedIndex = 1;

            this.Refresh();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }





        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
          Form form = new Form();
          Label label = new Label();
          TextBox textBox = new TextBox();
          Button buttonOk = new Button();
          Button buttonCancel = new Button();

          form.Text = title;
          label.Text = promptText;
          textBox.Text = value;

          buttonOk.Text = "OK";
          buttonCancel.Text = "Cancel";
          buttonOk.DialogResult = DialogResult.OK;
          buttonCancel.DialogResult = DialogResult.Cancel;

          label.SetBounds(9, 20, 372, 13);
          textBox.SetBounds(12, 36, 372, 20);
          buttonOk.SetBounds(228, 72, 75, 23);
          buttonCancel.SetBounds(309, 72, 75, 23);

          label.AutoSize = true;
          textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
          buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
          buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

          form.ClientSize = new Size(396, 107);
          form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
          form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
          form.FormBorderStyle = FormBorderStyle.FixedDialog;
          form.StartPosition = FormStartPosition.CenterScreen;
          form.MinimizeBox = false;
          form.MaximizeBox = false;
          form.AcceptButton = buttonOk;
          form.CancelButton = buttonCancel;

          DialogResult dialogResult = form.ShowDialog();
          value = textBox.Text;
          return dialogResult;
        }

        public static DialogResult InputBox2(string title, string promptText1, string promptText2, ref List<string> values)
        {
            Form form = new Form();
            Label label1 = new Label();
            Label label2 = new Label();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label1.Text = promptText1;
            label2.Text = promptText2;
            textBox1.Text = "";
            textBox2.Text = "";

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label1.SetBounds(9, 20, 372, 13);
            textBox1.SetBounds(12, 36, 372, 20);

            label2.SetBounds(9, 60, 372, 13);
            textBox2.SetBounds(12, 76, 372, 20);

            buttonOk.SetBounds(228, 120, 75, 23);
            buttonCancel.SetBounds(309, 120, 75, 23);

            label1.AutoSize = true;
            label2.AutoSize = true;
            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 170);
            form.Controls.AddRange(new Control[] { label1, textBox1, label2, textBox2, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label2.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            values.Add(textBox1.Text);
            values.Add(textBox2.Text);
            return dialogResult;
        }

        public static DialogResult InputBox3(string title, string promptText1, string promptText2, string promptText3, ref List<string> values)
        {
            Form form = new Form();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label1.Text = promptText1;
            label2.Text = promptText2;
            label3.Text = promptText3;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label1.SetBounds(9, 20, 372, 13);
            textBox1.SetBounds(12, 36, 372, 20);

            label2.SetBounds(9, 60, 372, 13);
            textBox2.SetBounds(12, 76, 372, 20);

            label3.SetBounds(9, 100, 372, 13);
            textBox3.SetBounds(12, 116, 372, 20);

            buttonOk.SetBounds(228, 150, 75, 23);
            buttonCancel.SetBounds(309, 150, 75, 23);

            label1.AutoSize = true;
            label2.AutoSize = true;
            textBox1.Anchor = textBox1.Anchor | AnchorStyles.Right;
            textBox2.Anchor = textBox2.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 200);
            form.Controls.AddRange(new Control[] { label1, textBox1, label2, textBox2, label3, textBox3, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label2.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            values.Add(textBox1.Text);
            values.Add(textBox2.Text);
            values.Add(textBox3.Text);
            return dialogResult;
        }


        private void studyDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(studyDisplay.SelectedIndex);
            if (studyDisplay.SelectedIndex == -1)
            {
                studyDisplay.ClearSelected();
            }
            else
            {
                currentStudy = database.GetStudies()[studyDisplay.SelectedIndex];
                Console.WriteLine(currentStudy.ToString());

                // Refresh the data windows
                subjectDisplay.DataSource = database.GetSubjects(currentStudy);
                ((CurrencyManager)subjectDisplay.BindingContext[subjectDisplay.DataSource]).Refresh();
                subjectDisplay.ClearSelected();

                sessionDisplay.DataSource = blankList;
                ((CurrencyManager)sessionDisplay.BindingContext[sessionDisplay.DataSource]).Refresh();
                //sessionDisplay.DataSource = null;
                //sessionDisplay.DataSource = currentSubject.sessions;
                //sessionDisplay.ClearSelected();

                trialDisplay.DataSource = blankList;
                ((CurrencyManager)trialDisplay.BindingContext[trialDisplay.DataSource]).Refresh();
                //trialDisplay.DataSource = null;
                //trialDisplay.DataSource = currentSession.trials;
                //trialDisplay.ClearSelected();
            }
        }

        private void removeStudy_Click(object sender, EventArgs e)
        {
            if (studyDisplay.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this study?", "Remove Study", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    currentStudy = database.GetStudies()[studyDisplay.SelectedIndex];
                    database.RemoveStudy(currentStudy);
                    currentStudy = null;

                    studyDisplay.DataSource = null;
                    studyDisplay.DataSource = database.GetStudies();
                }
            }
        }


        private void addNewSubject_Click(object sender, EventArgs e)
        {
            List<string> values = new List<string>();
            if (studyDisplay.SelectedIndex > -1)
            {
                DialogResult result = MainInterface.InputBox3("New Subject", "New Subject ID:", "New Subject Birthdate:", "New Subject Gender:", ref values);
                if (result == DialogResult.OK && values.Count > 0)
                {
                    Subject s = new Subject(values[0], values[1], values[2], currentStudy);
                    database.AddSubject(s);

                    subjectDisplay.DataSource = null;
                    subjectDisplay.DataSource = database.GetSubjects(currentStudy);
                    subjectDisplay.ClearSelected();
                    subjectDisplay.SetSelected(database.GetSubjectIndex(s), true);

                }
                else if (result == DialogResult.OK)
                {
                    MessageBox.Show("Invalid study name.");
                }
            }
        }

        private void removeSubject_Click(object sender, EventArgs e)
        {
            if (subjectDisplay.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this subject?", "Remove Subject", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    currentSubject = database.GetSubjects(currentStudy)[subjectDisplay.SelectedIndex];
                    database.RemoveSubject(currentSubject);
                    currentSubject = null;

                    subjectDisplay.DataSource = null;
                    subjectDisplay.DataSource = database.GetSubjects(currentStudy);
                }
            }
        }

        private void loadTracker_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Attempting to start tracker...");
            trackerinterface = new TrackerInterface(Convert.ToDouble(samplingFreq.Text) / 3.0, Convert.ToDouble(radiusSettings.SelectedValue), this);
            if (trackerinterface.init_error != 0)
            {
                MessageBox.Show("ERROR: Could not initialize tracker.  Is tracker plugged in and turned on?");
                Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
                return;
            }
            recorder = new Recorder(database);
            Console.WriteLine("Tracker initialized");
            startButton.Enabled = true;
            loadTracker.Enabled = false;
            unloadTracker.Enabled = true;
            samplingFreq.Enabled = false;
            radiusSettings.Enabled = false;

            startButton.BackColor = Color.Green;
            stopButton.BackColor = Color.DarkGray;
            nextTrial.BackColor = Color.DarkGray;
        }

        private void unloadTracker_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Shutting down tracker...");
            trackerinterface = null;
            recorder = null;
            startButton.Enabled = false;
            startButton.BackColor = Color.DarkGray;
            stopButton.BackColor = Color.DarkGray;
            nextTrial.BackColor = Color.DarkGray;
            loadTracker.Enabled = true;
            unloadTracker.Enabled = false;
            samplingFreq.Enabled = true;
            radiusSettings.Enabled = true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            // Begin recording

            //currentTrial = new Trial("test");
            recorder.Start(trackerinterface, currentTrial);

            Console.WriteLine("Recording started.");

            startButton.Enabled = false;
            stopButton.Enabled = true;
            nextTrial.Enabled = true;
            nextTrial.BackColor = Color.CadetBlue;
            ExportStudyButton.Enabled = false;
            startButton.BackColor = Color.DarkGray;
            stopButton.BackColor = Color.Red;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            // Stop recording
            recorder.Stop();

            stopButton.Enabled = false;
            startButton.Enabled = true;
            startButton.BackColor = Color.Green;
            stopButton.BackColor = Color.DarkGray;
            nextTrial.Enabled = false;
            nextTrial.BackColor = Color.DarkGray;
            
            ExportStudyButton.Enabled = true;

            // Now save, just in case!
        }

        private void nextTrial_Click(object sender, EventArgs e)
        {
            // Make a new trial and start adding to that.  No interruption can be allowed here.
            string curr_name = currentTrial.name;
            int numVal;
            try
            {
                numVal = Convert.ToInt32(curr_name);
                Trial t = new Trial(Convert.ToString(numVal + 1), DateTime.Now.ToString("H:mm:ss"), currentStudy, currentSubject, currentSession);
                database.AddTrial(t);

                trialDisplay.DataSource = null;
                trialDisplay.DataSource = database.GetTrials(currentSession);
                trialDisplay.ClearSelected();
                trialDisplay.SetSelected(database.GetTrialIndex(t), true);

                recorder.NextTrial(t);
            }
            catch (FormatException exp)
            {
                MessageBox.Show("Trial name is not numeric.");
                Console.WriteLine("Input string is not a sequence of digits.");
            }
        }

        private void addNewStudy_Click(object sender, EventArgs e)
        {
            string value = "";
            DialogResult result = MainInterface.InputBox("New Study", "New study name:", ref value);
            if (result == DialogResult.OK && value != "")
            {
                currentStudy = new Study(value);
                database.AddStudy(currentStudy);

                studyDisplay.DataSource = null;
                studyDisplay.DataSource = database.GetStudies();
                studyDisplay.ClearSelected();
                Console.WriteLine(database.GetStudies());
                studyDisplay.SetSelected(database.GetStudyIndex(currentStudy), true);
            }
            else if (result == DialogResult.OK)
            {
                MessageBox.Show("Invalid study name.");
            }

        }

        private void addNewSession_Click(object sender, EventArgs e)
        {
            string value = "";
            if (subjectDisplay.SelectedIndex > -1)
            {
                DialogResult result = MainInterface.InputBox("Create New Session", "Session Name:", ref value);
                if (result == DialogResult.OK)
                {
                    Session s = new Session(value, DateTime.Now.ToString("M/d/yyyy"), currentStudy, currentSubject);
                    database.AddSession(s);

                    sessionDisplay.DataSource = null;
                    sessionDisplay.DataSource = database.GetSessions(currentSubject);
                    ((CurrencyManager)sessionDisplay.BindingContext[sessionDisplay.DataSource]).Refresh();
                    sessionDisplay.ClearSelected();
                    sessionDisplay.SetSelected(database.GetSessionIndex(s), true);

                    Console.WriteLine(value);
                }
            }
        }

        private void removeSession_Click(object sender, EventArgs e)
        {
            Console.WriteLine(sessionDisplay.SelectedIndex);
            if (sessionDisplay.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this session?", "Remove Session", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    currentSession = database.GetSessions(currentSubject)[sessionDisplay.SelectedIndex];
                    database.RemoveSession(currentSession);
                    currentSession = null;

                    sessionDisplay.DataSource = null;
                    sessionDisplay.DataSource = database.GetSessions(currentSubject);
                }
            }
        }

        private void addTrial_Click(object sender, EventArgs e)
        {
            string value = "";
            if (sessionDisplay.SelectedIndex > -1)
            {
                DialogResult result = MainInterface.InputBox("Create New Trial", "Trial Name:", ref value);
                if (result == DialogResult.OK)
                {
                    Trial t = new Trial(value, DateTime.Now.ToString("H:mm:ss"), currentStudy, currentSubject, currentSession);
                    database.AddTrial(t);

                    trialDisplay.DataSource = null;
                    trialDisplay.DataSource = database.GetTrials(currentSession);
                    trialDisplay.ClearSelected();
                    trialDisplay.SetSelected(database.GetTrialIndex(t), true);

                }
            }
        }

        private void removeTrial_Click(object sender, EventArgs e)
        {
            if (sessionDisplay.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this trial?", "Remove Session", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    database.RemoveTrial(currentTrial);
                    currentTrial = null;
                    trialDisplay.DataSource = null;
                    trialDisplay.DataSource = database.GetTrials(currentSession);
                }
            }
        }

        private void subjectDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(subjectDisplay.SelectedIndex);
            if (subjectDisplay.SelectedIndex == -1)
            {
                subjectDisplay.ClearSelected();
            }
            else
            {
                currentSubject = database.GetSubjects(currentStudy)[subjectDisplay.SelectedIndex];
                Console.WriteLine(currentStudy.ToString());

                // Refresh the data windows
                sessionDisplay.DataSource = null;
                sessionDisplay.DataSource = database.GetSessions(currentSubject);
                //((CurrencyManager)sessionDisplay.BindingContext[sessionDisplay.DataSource]).Refresh();
                sessionDisplay.ClearSelected();

                trialDisplay.DataSource = blankList;
                ((CurrencyManager)trialDisplay.BindingContext[trialDisplay.DataSource]).Refresh();
                trialDisplay.ClearSelected();

            }
        }

        private void sessionDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine(sessionDisplay.SelectedIndex);
            if (sessionDisplay.SelectedIndex == -1)
            {
                sessionDisplay.ClearSelected();
            }
            else
            {
                currentSession = database.GetSessions(currentSubject)[sessionDisplay.SelectedIndex];

                // Refresh the data windows
                trialDisplay.DataSource = database.GetTrials(currentSession);
                ((CurrencyManager)trialDisplay.BindingContext[trialDisplay.DataSource]).Refresh();
                trialDisplay.ClearSelected();
                //trialDisplay.DataSource = null;
                //trialDisplay.DataSource = currentSession.trials;
                //trialDisplay.ClearSelected();
            }
        }

        private void trialDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trialDisplay.SelectedIndex == -1)
            {
                trialDisplay.ClearSelected();
            }
            else
            {
                currentTrial = database.GetTrials(currentSession)[trialDisplay.SelectedIndex];
                Console.WriteLine(currentTrial.ToString());
                //Console.WriteLine("This trial contains {0} frames of data!", database.GetSensorReadings(currentTrial).Count);

            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

        }

        private void getSensors_Click(object sender, EventArgs e)
        {
           // sensorInfo.Text = currentTrial.data.ElementAt(currentTrial.data.Count - 1).ToString();
        }

        public void UpdateSensorInfo(string text)
        {
            sensorInfo.Text = text;
        }

        public delegate void UpdateSensorInfoCallBack(string text);

        public delegate void UpdateSyncInfoCallBack(Boolean sync);

        public delegate void UpdateQualityChartInfoCallBack(List<string> seriesArray, List<int> qualityArray);

        public void UpdateSyncInfo(Boolean sync)
        {
            if (sync)
            {
                syncstatus.BackColor = Color.Green;
            }
            else
            {
                syncstatus.BackColor = Color.Red;
            }
        }
        public void UpdateQualityChart(List<string> seriesArray, List<int> qualityArray )
        {
            qualityChart.Series.Clear();
            for (int i = 0; i < seriesArray.Count; i++)
            {
                Series series = qualityChart.Series.Add(seriesArray.ElementAt(i));
                series.Points.Add(qualityArray.ElementAt(i));
            }
        }

        private void ExportStudyButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog sp = new FolderBrowserDialog();
            sp.RootFolder = Environment.SpecialFolder.Desktop;

            if (sp.ShowDialog() == DialogResult.OK)
            {
                // TODO: Commit task to BGWOrker
                ExportingProgress ep = new ExportingProgress();
                ep.Show();

                bw.DoWork += (_sender, _e) => _e.Result = runExportStudyByTrial(database, currentStudy, sp.SelectedPath);

                bw.RunWorkerAsync();
                //exporter.ExportSubjectToCSVOneFile(database, currentStudy, currentSubject, sp.FileName);
                while (bw.IsBusy)
                {
                    Thread.Sleep(100);
                    ep.currentFileLabel.Text = exporter.status;
                    ep.exportProgressBar.Update();
                    ep.exportProgressBar.Value = exporter.percent;
                    ep.Update();
                    Application.DoEvents();
                }
                ep.Hide();
            }
        }

        private void exportStudyOneFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sp = new SaveFileDialog();
            sp.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
            sp.Filter = "CSV File|*.csv";
            sp.Title = "Save study as one file.";


            if (sp.ShowDialog() == DialogResult.OK)
            {
                // TODO: Commit task to BGWOrker
                ExportingProgress ep = new ExportingProgress();
                ep.Show();

                bw.DoWork += (_sender, _e) => _e.Result = runExportStudy(database, currentStudy, sp.FileName);

                bw.RunWorkerAsync();
                //exporter.ExportSubjectToCSVOneFile(database, currentStudy, currentSubject, sp.FileName);
                while (bw.IsBusy)
                {
                    Thread.Sleep(100);

                    ep.exportProgressBar.Value = exporter.percent;
                    ep.currentFileLabel.Text = exporter.status;
                    ep.exportProgressBar.Update();
                    ep.Update();
                    Application.DoEvents();
                }
                ep.Hide();
            }
        }

        private void exportSubjectByTrialButton_Click(object sender, EventArgs e)
        {
            if(currentSubject != null) 
            {
                FolderBrowserDialog sp = new FolderBrowserDialog();
                sp.RootFolder = Environment.SpecialFolder.Desktop;


                if (sp.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Commit task to BGWOrker
                    ExportingProgress ep = new ExportingProgress();
                    ep.Show();
                    ep.exportProgressBar.Style = ProgressBarStyle.Continuous;

                    bw.DoWork += (_sender, _e) => _e.Result = runExportSubjectByTrial(database, currentStudy, currentSubject, sp.SelectedPath);

                    bw.RunWorkerAsync();
                    //exporter.ExportSubjectToCSVOneFile(database, currentStudy, currentSubject, sp.FileName);
                    while (bw.IsBusy)
                    {
                        Thread.Sleep(100);
                        ep.currentFileLabel.Text = exporter.status;
                        ep.exportProgressBar.Value = exporter.percent;
                        ep.exportProgressBar.Update();
                        ep.Update();
                        Application.DoEvents();
                    }
                    ep.Hide();
                }
            }
        }

        private void exportSubjectButton_Click(object sender, EventArgs e)
        {
            if (currentSubject != null)
            {
                SaveFileDialog sp = new SaveFileDialog();
                sp.InitialDirectory = Environment.SpecialFolder.Desktop.ToString();
                sp.Filter = "CSV File|*.csv";
                sp.Title = "Save study as one file.";


                if (sp.ShowDialog() == DialogResult.OK)
                {
                    // TODO: Commit task to BGWOrker
                    ExportingProgress ep = new ExportingProgress();
                    ep.Show();

                    bw.DoWork += (_sender, _e) => _e.Result = runExportSubject(database, currentStudy, currentSubject, sp.FileName);

                    bw.RunWorkerAsync();
                    //exporter.ExportSubjectToCSVOneFile(database, currentStudy, currentSubject, sp.FileName);
                    while (bw.IsBusy)
                    {
                        Thread.Sleep(100);
                        ep.currentFileLabel.Text = exporter.status;
                        ep.exportProgressBar.Value = exporter.percent;
                        ep.exportProgressBar.Update();
                        ep.Update();
                        Application.DoEvents();
                    }
                    ep.Hide();
                }
            }
        }

        public Exporter runExportStudy(DatabaseControl database, Study currentStudy, String filename)
        {
            Thread.Sleep(100);
            exporter.ExportStudyToCSVOneFile(database, currentStudy, filename);
            return exporter;
        }

        public Exporter runExportStudyByTrial(DatabaseControl database, Study currentStudy, String directory)
        {
            Thread.Sleep(100);
            exporter.ExportStudyToMultipleFiles(database, currentStudy, directory);
            return exporter;
        }

        public Exporter runExportSubject(DatabaseControl database, Study currentStudy, Subject currentSubject, String filename)
        {
            Thread.Sleep(100);
            exporter.ExportSubjectToCSVOneFile(database, currentStudy, currentSubject, filename);
            return exporter;
        }

        public Exporter runExportSubjectByTrial(DatabaseControl database, Study currentStudy, Subject currentSubject, String directory)
        {
            Thread.Sleep(100);
            exporter.ExportSubjectToMultipleFiles(database, currentStudy, currentSubject, directory);
            return exporter;
        }


        private void MainInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void updateOldTimestampsButton_Click(object sender, EventArgs e)
        {
            ExportingProgress ep = new ExportingProgress();
            ep.Show();
            database.updateTimestamps();
            ep.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void radiusSettings_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void samplingFreq_TextChanged(object sender, EventArgs e)
        {

        }















    }
}
