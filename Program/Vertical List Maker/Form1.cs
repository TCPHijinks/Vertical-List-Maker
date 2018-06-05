﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Vertical_List_Maker
{
	public partial class Form1 : Form
	{
		string
			inputPath,
			outputPath,
			whitelistPath,
			newlineTriggerPath;

		string
			whitelist,
			newlineTrigger;


		public Form1()
		{
			// Initialize form icon.
			ComponentResourceManager resources = new ComponentResourceManager(typeof(Form));
			Icon = new Icon("Resources/icon.ico");

			// Default paths.
			whitelistPath = Path.Combine(Environment.CurrentDirectory, "Settings/defaultWhitelist.txt");
			newlineTriggerPath = Path.Combine(Environment.CurrentDirectory, "Settings/defaultNewLineTrigger.txt");

			// Set default filter values.
			whitelist = Program.ReadFile(whitelistPath, false)[1];
			newlineTrigger = Program.ReadFile(newlineTriggerPath, false)[1];
						
			InitializeComponent();
			
			// Lock form size.
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			MinimizeBox = false;
		}

		private void InputFIle_Click(object sender, EventArgs e)
		{
			string[] read = Program.ReadFile("",true);
			inputPath = read[0];
			textBox1.Text = inputPath;			
		}

		private void OutputFile_Click(object sender, EventArgs e)
		{
			string[] read = Program.ReadFile("", true);
			outputPath = read[0];
			textBox2.Text = outputPath;
		}

		private void GenerateList_Click(object sender, EventArgs e)
		{
			string[] read = Program.ReadFile(inputPath, false);
			string list = read[1];
			Program.BuildList(list, outputPath, whitelist, newlineTrigger);
		}

		private void LoadWhitelist_Click(object sender, EventArgs e)
		{
			string[] read = Program.ReadFile("", true);
			whitelistPath = read[0];
			whitelist = read[1];			
		}

		private void LoadNewLineTrigger_Click(object sender, EventArgs e)
		{
			string[] read = Program.ReadFile("", true);
			newlineTriggerPath = read[0];
			newlineTrigger = read[1];
		}
	}
}
