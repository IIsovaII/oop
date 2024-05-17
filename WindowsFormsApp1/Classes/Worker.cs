﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public class Worker : Person
    {
        private string _job;
        private int _aviaryForCare;
        private bool isBuzy { get; set; }

        public string job { get => _job; set => _job = value; }
        public int aviaryForCare { get => _aviaryForCare; set => _aviaryForCare = value; }

        public Worker(string Name, string Sex, string job, int an, bool isBuzy = false) : base(Name, Sex)
        {
            this._job = job;
            this._aviaryForCare = an;
            this.isBuzy = isBuzy;
        }

        public void showStatus()
        {
            MessageBox.Show($"Name: {this.name}\n" + 
                            $"Sex: {this.sex}\n" + 
                            $"Job: {this.job}\n" +
                            (isBuzy ? "I'm buzy!" : "I'm free"));
        }

        private void BuzyChange()
        {
            this.isBuzy = !this.isBuzy;
        }

        public bool IsBuzy()
        {
            return this.isBuzy;
        }

        public void Feeding(IAviary aviary)
        {
            if (isBuzy) this.BuzyChange();

            if (aviary.ShowFeederFullness() < aviary.ShowSize())
            {
                this.BuzyChange();
                aviary.PlusFeed(1);
            }
        }
    }
}
