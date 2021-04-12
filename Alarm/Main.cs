using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Alarm
{
    public partial class Main : Form
    {
        String day = "";
        public Main()
        {
            InitializeComponent();
        }

        SoundPlayer tone;

        private void Main_Load(object sender, EventArgs e)
        {
            timer_currentTime.Start();
        }

        private void timer_currentTime_Tick(object sender, EventArgs e)
        {
            lbl_nowTime.Text = DateTime.Now.ToLongTimeString();
            String dateTime = DateTime.Now.ToLongDateString();
            int i = dateTime.IndexOf(',');
            int len = dateTime.Length - i - 2;
            lbl_nowDate.Text = dateTime.Substring(0, i);
            day = dateTime.Substring(i + 2, len);
            lbl_nowDay.Text = day;
        }

        private void p_top_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gp_setAlarm.Enabled = true;
        }

        private void tb_timeH_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_timeH_Enter(object sender, EventArgs e)
        {
            tb_timeH1.Text = "";
        }

        private void tb_timeM_Enter(object sender, EventArgs e)
        {
            tb_timeM1.Text = "";
        }

        private void tb_timeS_Enter(object sender, EventArgs e)
        {
            tb_timeS1.Text = "";
        }

        private void tb_timeH_Leave(object sender, EventArgs e)
        {
            if (tb_timeH1.Text == "") tb_timeH1.Text = "00";
            else
            {
                int hours = Int32.Parse(tb_timeH1.Text);
                if (hours >= 24)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timeH1.Text = "23";
                    MessageBox.Show("Hours can not be greater than 24!", "Error");
                }
            }
        }

        private void tb_timeM_Leave(object sender, EventArgs e)
        {
            if (tb_timeM1.Text == "") tb_timeM1.Text = "00";
            else
            {
                int minutes = Int32.Parse(tb_timeM1.Text);
                if (minutes >= 60)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timeM1.Text = "59";
                    MessageBox.Show("Minutes can not be greater than 60!", "Error");
                }
            }
        }

        private void tb_timeS_Leave(object sender, EventArgs e)
        {
            if (tb_timeS1.Text == "") tb_timeS1.Text = "00";
            else
            {
                int seconds = Int32.Parse(tb_timeS1.Text);
                if (seconds >= 60)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timeS1.Text = "59";
                    MessageBox.Show("Seconds can not be greater than 60!", "Error");
                }
            }
        }

        private void btn_onAlarm_Click(object sender, EventArgs e)
        {
            if (btn_offAlarm1.BackColor == Color.Lime)
            {
                btn_offAlarm1.BackColor = Color.Silver;
                btn_onAlarm1.BackColor = Color.Red;
                btn_offAlarm1.Text = "I I I";
                btn_onAlarm1.Text = "";
                timer_alarm1.Stop();
            }
            else
            {
                btn_offAlarm1.BackColor = Color.Lime;
                btn_onAlarm1.BackColor = Color.Silver;
                btn_onAlarm1.Text = "I I I";
                btn_offAlarm1.Text = "";
                timer_alarm1.Start();
            }

        }

        private void btn_offAlarm_Click(object sender, EventArgs e)
        {
            if (btn_offAlarm1.BackColor == Color.Silver)
            {
                btn_offAlarm1.BackColor = Color.Lime;
                btn_onAlarm1.BackColor = Color.Silver;
                btn_onAlarm1.Text = "I I I";
                btn_offAlarm1.Text = "";
                timer_alarm1.Start();
            }
            else
            {
                btn_offAlarm1.BackColor = Color.Silver;
                btn_onAlarm1.BackColor = Color.Red;
                btn_offAlarm1.Text = "I I I";
                btn_onAlarm1.Text = "";
                timer_alarm1.Stop();
            }

        }

        private void timer_alarm_Tick(object sender, EventArgs e)
        {
            string time = "";
            time += tb_timeH1.Text + ":" + tb_timeM1.Text + ":" + tb_timeS1.Text;
            if (time == lbl_nowTime.Text)
            {
                if (day == "bazar ertəsi" && cb_be1.Checked)
                {
                    playTone(cb_tones1);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "çərşənbə axşamı" && cb_ca1.Checked)
                {
                    playTone(cb_tones1);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "çərşənbə" && cb_c1.Checked)
                {
                    playTone(cb_tones1);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "cümə axşamı" && cb_cma1.Checked)
                {
                    playTone(cb_tones1);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "cümə" && cb_cm1.Checked)
                {
                    playTone(cb_tones1);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "şənbə" && cb_s1.Checked)
                {
                    playTone(cb_tones1);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "bazar" && cb_b1.Checked)
                {
                    playTone(cb_tones1);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
            }
        }

        private void tb_timeH_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void playTone(ComboBox cb_tones)
        {
            switch (cb_tones.Text)
            {
                case "Weather sound":
                    tone = new SoundPlayer(@"audio\Weather.wav");
                    tone.Play();
                    break;
                case "Classic ringtone":
                    tone = new SoundPlayer(@"audio\Classic.wav");
                    tone.Play();
                    break;
                case "Iphone alarm ringtone":
                    tone = new SoundPlayer(@"audio\Iphone.wav");
                    tone.Play();
                    break;
                case "Xiaomi alarm ringtone":
                    tone = new SoundPlayer(@"audio\Xiaomi.wav");
                    tone.Play();
                    break;
                case "Keloglan":
                    tone = new SoundPlayer(@"audio\Keloglan.wav");
                    tone.Play();
                    break;
            }
        }

        private void btn_onAlarm2_Click(object sender, EventArgs e)
        {
            if (btn_offAlarm2.BackColor == Color.Lime)
            {
                btn_offAlarm2.BackColor = Color.Silver;
                btn_onAlarm2.BackColor = Color.Red;
                btn_offAlarm2.Text = "I I I";
                btn_onAlarm2.Text = "";
                timer_alarm2.Stop();
            }
            else
            {
                btn_offAlarm2.BackColor = Color.Lime;
                btn_onAlarm2.BackColor = Color.Silver;
                btn_onAlarm2.Text = "I I I";
                btn_offAlarm2.Text = "";
                timer_alarm2.Start();
            }

        }

        private void btn_offAlarm2_Click(object sender, EventArgs e)
        {
            if (btn_offAlarm2.BackColor == Color.Silver)
            {
                btn_offAlarm2.BackColor = Color.Lime;
                btn_onAlarm2.BackColor = Color.Silver;
                btn_onAlarm2.Text = "I I I";
                btn_offAlarm2.Text = "";
                timer_alarm2.Start();
            }
            else
            {
                btn_offAlarm2.BackColor = Color.Silver;
                btn_onAlarm2.BackColor = Color.Red;
                btn_offAlarm2.Text = "I I I";
                btn_onAlarm2.Text = "";
                timer_alarm2.Stop();
            }

        }

        private void btn_onAlarm3_Click(object sender, EventArgs e)
        {
            if (btn_offAlarm3.BackColor == Color.Lime)
            {
                btn_offAlarm3.BackColor = Color.Silver;
                btn_onAlarm3.BackColor = Color.Red;
                btn_offAlarm3.Text = "I I I";
                btn_onAlarm3.Text = "";
                timer_alarm3.Stop();
            }
            else
            {
                btn_offAlarm3.BackColor = Color.Lime;
                btn_onAlarm3.BackColor = Color.Silver;
                btn_onAlarm3.Text = "I I I";
                btn_offAlarm3.Text = "";
                timer_alarm3.Start();
            }
        }

        private void btn_offAlarm3_Click(object sender, EventArgs e)
        {
            if (btn_offAlarm3.BackColor == Color.Silver)
            {
                btn_offAlarm3.BackColor = Color.Lime;
                btn_onAlarm3.BackColor = Color.Silver;
                btn_onAlarm3.Text = "I I I";
                btn_offAlarm3.Text = "";
                timer_alarm3.Start();
            }
            else
            {
                btn_offAlarm3.BackColor = Color.Silver;
                btn_onAlarm3.BackColor = Color.Red;
                btn_offAlarm3.Text = "I I I";
                btn_onAlarm3.Text = "";
                timer_alarm3.Stop();
            }

        }

        private void timer_alarm2_Tick(object sender, EventArgs e)
        {
            string time = "";
            time += tb_timeH2.Text + ":" + tb_timeM2.Text + ":" + tb_timeS2.Text;
            if (time == lbl_nowTime.Text)
            {
                if (day == "bazar ertəsi" && cb_be2.Checked)
                {
                    playTone(cb_tones2);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "çərşənbə axşamı" && cb_ca2.Checked)
                {
                    playTone(cb_tones2);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "çərşənbə" && cb_c2.Checked)
                {
                    playTone(cb_tones2);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "cümə axşamı" && cb_cma2.Checked)
                {
                    playTone(cb_tones2);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "cümə" && cb_cm2.Checked)
                {
                    playTone(cb_tones2);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "şənbə" && cb_s2.Checked)
                {
                    playTone(cb_tones2);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "bazar" && cb_b2.Checked)
                {
                    playTone(cb_tones2);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
            }
        }

        private void timer_alarm3_Tick(object sender, EventArgs e)
        {
            string time = "";
            time += tb_timeH3.Text + ":" + tb_timeM3.Text + ":" + tb_timeS3.Text;
            if (time == lbl_nowTime.Text)
            {
                if (day == "bazar ertəsi" && cb_be3.Checked)
                {
                    playTone(cb_tones3);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "çərşənbə axşamı" && cb_ca3.Checked)
                {
                    playTone(cb_tones3);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "çərşənbə" && cb_c3.Checked)
                {
                    playTone(cb_tones3);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "cümə axşamı" && cb_cma3.Checked)
                {
                    playTone(cb_tones3);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "cümə" && cb_cm3.Checked)
                {
                    playTone(cb_tones3);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "şənbə" && cb_s3.Checked)
                {
                    playTone(cb_tones3);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
                else if (day == "bazar" && cb_b3.Checked)
                {
                    playTone(cb_tones3);
                    MessageBox.Show("Wake up!", "Alarm");
                    tone.Stop();
                }
            }
        }

        private void tb_timeH2_Enter(object sender, EventArgs e)
        {
            tb_timeH2.Text = "";
        }

        private void tb_timeM2_Enter(object sender, EventArgs e)
        {
            tb_timeM2.Text = "";
        }

        private void tb_timeS2_Enter(object sender, EventArgs e)
        {
            tb_timeS2.Text = "";
        }

        private void tb_timeH2_Leave(object sender, EventArgs e)
        {
            if (tb_timeH2.Text == "") tb_timeH2.Text = "00";
            else
            {
                int hours = Int32.Parse(tb_timeH2.Text);
                if (hours >= 24)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timeH2.Text = "23";
                    MessageBox.Show("Hours can not be greater than 24!", "Error");
                }
            }
        }

        private void tb_timeM2_Leave(object sender, EventArgs e)
        {
            if (tb_timeM2.Text == "") tb_timeM2.Text = "00";
            else
            {
                int minutes = Int32.Parse(tb_timeM2.Text);
                if (minutes >= 60)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timeM2.Text = "59";
                    MessageBox.Show("Minutes can not be greater than 60!", "Error");
                }
            }
        }

        private void tb_timeS2_Leave(object sender, EventArgs e)
        {
            if (tb_timeS2.Text == "") tb_timeS2.Text = "00";
            else
            {
                int minutes = Int32.Parse(tb_timeS2.Text);
                if (minutes >= 60)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timeS2.Text = "59";
                    MessageBox.Show("Seconds can not be greater than 60!", "Error");
                }
            }
        }

        private void tb_timeH3_Enter(object sender, EventArgs e)
        {
            tb_timeH3.Text = "";
        }

        private void tb_timeM3_Enter(object sender, EventArgs e)
        {
            tb_timeM3.Text = "";
        }

        private void tb_timeS3_Enter(object sender, EventArgs e)
        {
            tb_timeS3.Text = "";
        }

        private void tb_timeH3_Leave(object sender, EventArgs e)
        {
            if (tb_timeH3.Text == "") tb_timeH3.Text = "00";
            else
            {
                int hours = Int32.Parse(tb_timeH3.Text);
                if (hours >= 24)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timeH3.Text = "23";
                    MessageBox.Show("Hours can not be greater than 24!", "Error");
                }
            }
        }

        private void tb_timeM3_Leave(object sender, EventArgs e)
        {
            if (tb_timeM3.Text == "") tb_timeM3.Text = "00";
            else
            {
                int minutes = Int32.Parse(tb_timeM3.Text);
                if (minutes >= 60)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timeM3.Text = "59";
                    MessageBox.Show("Minutes can not be greater than 60!", "Error");
                }
            }
        }

        private void tb_timeS3_Leave(object sender, EventArgs e)
        {
            if (tb_timeS3.Text == "") tb_timeS3.Text = "00";
            else
            {
                int minutes = Int32.Parse(tb_timeS3.Text);
                if (minutes >= 60)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timeS3.Text = "59";
                    MessageBox.Show("Seconds can not be greater than 60!", "Error");
                }
            }
        }
        private void tb_timerH_Enter(object sender, EventArgs e)
        {
            tb_timerH.Text = "";
        }

        private void tb_timerM_Enter(object sender, EventArgs e)
        {
            tb_timerM.Text = "";
        }

        private void tb_timerS_Enter(object sender, EventArgs e)
        {
            tb_timerS.Text = "";
        }

        private void tb_timerH_Leave(object sender, EventArgs e)
        {
            if (tb_timerH.Text == "") tb_timerH.Text = "00";
        }

        private void tb_timerM_Leave(object sender, EventArgs e)
        {
            if (tb_timerM.Text == "") tb_timerM.Text = "00";
            else
            {
                int minutes = Int32.Parse(tb_timerM.Text);
                if (minutes >= 60)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timerM.Text = "59";
                    MessageBox.Show("Minutes can not be greater than 60!", "Error");
                }
            }
        }

        private void tb_timerS_Leave(object sender, EventArgs e)
        {
            if (tb_timerS.Text == "") tb_timerS.Text = "00";
            else
            {
                int minutes = Int32.Parse(tb_timerS.Text);
                if (minutes >= 60)
                {
                    tone = new SoundPlayer(@"audio\Error.wav");
                    tone.Play();
                    tb_timerS.Text = "59";
                    MessageBox.Show("Seconds can not be greater than 60!", "Error");
                }
            }
        }

        private void btn_startTimer_Click(object sender, EventArgs e)
        {
            timer.Start();
            tb_timerH.Enabled = false;
            tb_timerM.Enabled = false;
            tb_timerS.Enabled = false;
            btn_startTimer.Enabled = false;
            btn_stopTimer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int hour = Int32.Parse(tb_timerH.Text), minute = Int32.Parse(tb_timerM.Text), second = Int32.Parse(tb_timerS.Text);
            if (hour == 0 && minute == 0 && second == 0)
            {
                tone = new SoundPlayer(@"audio\Timer.wav");
                tone.Play();
                tb_timerM.Text = "01";
                timer.Stop();
                MessageBox.Show("Time is over!", "Timer");
                tone.Stop();
            }
            else
            {
                if (second != 0)
                {
                    second--;
                    if (second / 10 == 0) tb_timerS.Text = "0" + second.ToString();
                    else tb_timerS.Text = second.ToString();
                }
                else if (minute !=0)
                {
                    minute--;
                    if (second / 10 == 0) tb_timerM.Text = "0" + minute.ToString();
                    else tb_timerM.Text = minute.ToString();
                    tb_timerS.Text = "59";
                }
                else if (hour != 0)
                {
                    hour--;
                    if (second / 10 == 0) tb_timerH.Text = "0" + hour.ToString();
                    else tb_timerH.Text = hour.ToString();
                    tb_timerM.Text = "59";
                    tb_timerS.Text = "59";
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            timer.Stop();
            btn_startTimer.Enabled = true;
            btn_stopTimer.Enabled = false;
            tb_timerH.Enabled = true;
            tb_timerM.Enabled = true;
            tb_timerS.Enabled = true;
        }
    }

    
}
