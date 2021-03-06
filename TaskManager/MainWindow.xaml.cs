﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System;
using System.Windows.Markup;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Timers;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics.PerformanceData;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public List<Process> removed = new List<Process>();
        public Process[] localAll;
        public string[] unkillable = new string[] { "bellservice", "ibsaservice", "pc-client", "m_agent_service" };
        Timer updateTimer = new Timer();
        Timer cpupdateTimer = new Timer();

        public void update(object source, ElapsedEventArgs e)
        {
            //MessageBox.Show("update");
            updateTimer.Interval = 2500;
            Dispatcher.Invoke(() =>
            {


                refresh();
                //close = false;
                //MessageBox.Show(close.ToString());

            });
        }
        public void cpuupdate(object source, ElapsedEventArgs e)
        {
            //MessageBox.Show("update");
            updateTimer.Interval = 1500;
            Dispatcher.Invoke(() =>
            {


                PerformanceCounter cpuCounter;
                //PerformanceCounter ramCounter;

                cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                cpuCounter.NextValue();
                System.Threading.Thread.Sleep(100);
                int val = (int)cpuCounter.NextValue();
                CPU_bar.Value = val;
                CPU_percent.Text = val + "%";
                //close = false;
                //MessageBox.Show(close.ToString());

            });
        }
        public MainWindow()
        {

            localAll = Process.GetProcesses();
            InitializeComponent();
            if (File.Exists("C:/DrEthanTemp/taskmanagerconfig.cfg"))
            {
                TextReader tr = new StreamReader("C:/DrEthanTemp/taskmanagerconfig.cfg");
                bool tempbool = false;
                bool.TryParse(tr.ReadLine(), out tempbool);
                tr.Close();
                checkbox.IsChecked = tempbool;

            }
            if (File.Exists("C:/DrEthanTemp/Ethan.bkdr"))
            {
                unkillable = new string[0];
            }
            Ping ping = new Ping();
            Console.WriteLine("start");
            //GetCpuUsage();
            this.Title = "Task Manager Lite";
            updateTimer.Elapsed += new ElapsedEventHandler(update);
            updateTimer.Interval = 2500;
            updateTimer.Enabled = true;
            cpupdateTimer.Elapsed += new ElapsedEventHandler(cpuupdate);
            cpupdateTimer.Interval = 1500;
            cpupdateTimer.Enabled = true;
            refresh();
        }
        public static T GetChildOfType<T>(DependencyObject depObj)
    where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //localAll
            List<string> templist = new List<string>();
            int temp = proccesspanel.Children.Count;
            for (int i = 0; i < temp; i++)
            {
                proccesspanel.Children.Remove(proccesspanel.Children[0]);
            }
            //localAll.OrderByDescending()
            refresh();
        }

        private void endprocess_Click(object sender, RoutedEventArgs e)
        {
            string untempered = string.Format("{0}", (sender as Button).Tag);

            string name = untempered.Remove(untempered.IndexOf(":"));
            string PID = untempered.Remove(0, untempered.IndexOf(":") + 1);
            if (bool.Parse(checkbox.IsChecked.ToString()))
            {
                switch (MessageBox.Show("End all the instances of the " + name + " process? \n (You will most likely lose any unsaved work you have created)", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Question))
                {
                    case (MessageBoxResult.OK):
                        if (findindex(PID) == int.MaxValue)
                        {
                            MessageBox.Show("There was an error contact the admin(" + PID + ")", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            for (int i = 0; i < localAll.Length; i++)
                            {
                                if (localAll[i].ProcessName == name)
                                {
                                    if (!localAll[i].HasExited)
                                    {
                                        localAll[i].Kill();
                                        //WaitForChangedResult;

                                        //localAll[0].Exited
                                        removed.Add(localAll[i]);

                                    }
                                    else
                                    {
                                        removed.Add(localAll[i]);
                                        //refresh();
                                        //MessageBox.Show("That Process is already quitting.", "Notification", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                    }
                                }
                            }
                            updateTimer.Interval = 100;

                            for (int i = 0; i < localAll.Count(); i++)
                            {
                                if (localAll[i].ProcessName.Contains(name))
                                {
                                    bool quitted = false;
                                    try
                                    {
                                        quitted = localAll[i].HasExited;
                                    }
                                    catch (Exception e2)
                                    {
                                        Console.WriteLine(e2.Message);
                                    }
                                    if (quitted)
                                    {
                                        removed.Add(localAll[i]);
                                    }
                                    //refresh();
                                }
                            }

                            refresh();
                            //filter.Text = "";
                        }
                        break;
                    case (MessageBoxResult.Cancel):

                        break;
                }
            }
            else
            {
                if (!localAll[findindex(PID)].HasExited)
                {
                    switch (MessageBox.Show("End the " + name + " process? \n (You will most likely lose any unsaved work you have created)", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Question))
                    {
                        case (MessageBoxResult.OK):
                            if (findindex(PID) == -1)
                            {
                                MessageBox.Show("There was an error contact the admin(" + PID + ")", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                localAll[findindex(PID)].Kill();
                                //WaitForChangedResult;
                                updateTimer.Interval = 100;
                                //localAll[0].Exited
                                removed.Add(localAll[findindex(PID)]);
                                int index = findindex(PID);
                                for (int i = 0; i < localAll.Count(); i++)
                                {
                                    if (localAll[i].ProcessName.Contains(localAll[index].ProcessName))
                                    {
                                        bool quitted = false;
                                        try
                                        {
                                            quitted = localAll[i].HasExited;
                                        }
                                        catch (Exception e2)
                                        {
                                            Console.WriteLine(e2.Message);
                                        }
                                        if (quitted)
                                            removed.Add(localAll[i]);
                                        //refresh();
                                    }
                                }

                                refresh();
                                //filter.Text = "";
                            }
                            break;
                        case (MessageBoxResult.Cancel):

                            break;
                    }
                }
                else
                {
                    removed.Add(localAll[findindex(PID)]);
                    refresh();
                    MessageBox.Show("That Process is already quitting.", "Notification", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
        public int findindex(string pid)
        {
            for (int i = 0; i < localAll.Length; i++)
            {
                if (localAll[i].Id.ToString() == pid)
                {
                    return i;
                }
            }
            return -1;
        }
        public void refresh()
        {
            //GetCpuUsage();

            localAll = Process.GetProcesses();
            PerformanceCounter ramCounter;

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            ulong installed = new ComputerInfo().TotalPhysicalMemory / 1024 / 1024;
            float ramuse = ramCounter.NextValue();
            Ram_use.Text = Math.Round(((float.Parse(installed.ToString()) - float.Parse(ramuse.ToString())) / float.Parse(installed.ToString())) * 100f).ToString() + "%";
            Ram_bar.Value = Math.Round(((float.Parse(installed.ToString()) - float.Parse(ramuse.ToString())) / float.Parse(installed.ToString())) * 100f);
            List<string> templist = new List<string>();
            List<string> collapselist = new List<string>();
            int temp = proccesspanel.Children.Count;
            for (int i = 0; i < temp; i++)
            {
                proccesspanel.Children.Remove(proccesspanel.Children[0]);
            }
            for (int i = 0; i < localAll.Length; i++)
            {

                if (!removed.Contains(localAll[i]) && (!unkillable.Contains(localAll[i].ProcessName.ToLower())))
                {
                    if (!unkillable.Contains(localAll[i].ProcessName))
                    {
                        if (localAll[i].ProcessName.ToLower().Contains(filter.Text.ToLower()))
                        {
                            if (bool.Parse(checkbox.IsChecked.ToString()))
                            {
                                if (!collapselist.Contains(localAll[i].ProcessName))
                                {
                                    collapselist.Add(localAll[i].ProcessName);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            Button bt = new Button();
                            long ram = 0;
                            ram = (localAll[i].WorkingSet64 / 1024 / 1024);
                            if (bool.Parse(checkbox.IsChecked.ToString()))
                            {
                                int tempnotresp = 0;
                                for (int x = 0; x < localAll.Length; x++)
                                {
                                    if (localAll[x].Id != localAll[i].Id && localAll[x].ProcessName == localAll[i].ProcessName)
                                    {
                                        ram += (localAll[x].WorkingSet64 / 1024 / 1024);
                                        if (!localAll[x].Responding)
                                            tempnotresp++;
                                    }
                                }
                                if (!(tempnotresp > 0))
                                    bt.Content = localAll[i].ProcessName + "|| RAM:" + ram.ToString() + "MB";
                                else
                                    bt.Content = "!" + tempnotresp + " NOT RESPONDING! " + localAll[i].ProcessName + "|| RAM:" + (localAll[i].WorkingSet64 / 1024 / 1024).ToString() + "MB";
                            }
                            else
                            {
                                if (localAll[i].Responding)
                                    bt.Content = localAll[i].ProcessName + "|| PID:" + localAll[i].Id + "|| RAM:" + ram.ToString() + "MB";
                                else
                                    bt.Content = "!NOT RESPONDING! " + localAll[i].ProcessName + "|| PID:" + localAll[i].Id + "|| RAM:" + (localAll[i].WorkingSet64 / 1024 / 1024).ToString() + "MB";
                            }

                            //name.
                            bt.Click += new RoutedEventHandler(endprocess_Click);
                            if (bool.Parse(checkbox.IsChecked.ToString()))
                            {
                                bt.Tag = localAll[i].ProcessName + ": Multi";
                            }
                            else
                            {

                                bt.Tag = localAll[i].ProcessName + ":" + localAll[i].Id;
                            }
                            //MessageBox.Show(GetChildOfType<Button>(newGrid).Tag.ToString());
                            if (removed.Count > 0 && localAll[i].Id == removed[0].Id)
                            {
                                removed.Remove(localAll[i]);
                            }
                            else
                            {
                                proccesspanel.Children.Add(bt);
                            }
                        }
                    }
                }

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //if (!File.Exists)
            Directory.CreateDirectory("C:/DrEthanTemp");
            File.SetAttributes("C:/DrEthanTemp", FileAttributes.Hidden);
            //File.CreateText("C:/DrEthanTemp/taskmanagerconfig.cfg");
            TextWriter tw = new StreamWriter("C:/DrEthanTemp/taskmanagerconfig.cfg");
            tw.Write(checkbox.IsChecked);
            tw.Close();
            refresh();
        }
    }
}
