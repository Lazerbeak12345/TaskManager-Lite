   M S B A M L   `   `   `  ���� F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager      TaskManager.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:TaskManager       � Title$  
MainWindow��$��570.112��$	��525�� � 
ResizeMode$ NoResize=�.��� .+��� $
��Left=�$	��465��$��	10,64,0,0q�$	��Top=�$	��497�����	#FFBB4141.���� -    ��Name$ proccesspanel���� -    ��Name$ filter��$
��Left=�$��23��$��	10,36,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��497���� -    ��Name$ example��$��Button��$
��Left=�$��
10,-63,0,0q�$	��Top=�$	��469�����	#00DDDDDD�� $
��Left=�$��	10,20,0,0q�$
��Wrap=�$	��Top=��� $�Filter���� �� �� -   $��Refresh��$
��Left=�$��
432,10,0,0q�$	��Top=�$��75���� -    ��Name$ checkbox��$��Collapse Similar��$
��Left=�$	��Top=�$��20��$	��112��$��10,8,0,0q�� -    �Name$ Ram_bar��$
��Left=�$��20��$��
138,10,0,0q�$	��Top=�$	��122��� -   $ CPU_bar��$
��Left=�$��20��$��
289,10,0,0q�$	��Top=�$	��122���� $
��Left=�$��18��$��
289,11,0,0q�$
��Wrap=�$��
CPU usage:��$	��Top=�$��63���� $
��Left=�$��
138,11,0,0q�$
��Wrap=�$��
RAM Usage:��$	��Top=� J� RenderTransformOrigin$ -0.571,0&�$��19���� -   	 ��Name$	 Ram_use��$
��Left=�$��19��$��
207,11,0,0q�$
��Wrap=�$��0%��$	��Top=�$��53��$ 2.237,-6.684&��� -	   $	 CPU_percent��$
��Left=�$��
352,11,0,0q�$
��Wrap=�$��0%��$	��Top=�$��19��$��59��