   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:TaskManagerTaskManager  5   	       TaskManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:TaskManager     5   	     � Title$  
MainWindow��5   	   $��570.112��6   $	��525��6-    � 
ResizeMode$ NoResize=�69   .��5	      � .+�5   
   �� $
��Left=�6   $	��465��62   $��	10,64,0,0q�6?   $	��Top=�6R   $	��497��6j   ���	#FFBB4141.��5      �� -   5         ��Name$ proccesspanel��5      5      �� 5   
   -   5         ��Name$ filter��5      $
��Left=�6"   $��23��6=   $��	10,36,0,0q�6I    �� TextWrapping$
 Wrap=�6\   $	��Top=�6p   $	��497��6�   6�   �� 5   
   -   5         ��Name$ example��5      $��Button��6"   $
��Left=�63   $��
10,-63,0,0q�6N   $	��Top=�6b   $	��469��6z   ���	#00DDDDDD6�   �� 5   
   $
��Left=�6   $��	10,20,0,0q�6/   $
��Wrap=�6B   $	��Top=�6V   �� 6o   $�Filter��6s   �� 6�   �� 6�   6�   �� 5   
   -   5        $��Refresh��5      $
��Left=�6#   $��
432,10,0,0q�6>   $	��Top=�6R   $��75��6j   6u   �� 5   
   -   5         ��Name$ checkbox��5      $��Collapse Similar��6%   $
��Left=�6@   $	��Top=�6[   $��20��6s   $	��112��6   $��10,8,0,0q�6�   6�   � 5   
   -   5         �Name$ Ram_bar��5      $
��Left=�6'   $��20��6B   $��
138,10,0,0q�6N   $	��Top=�6b   $	��122��6z   � 5   
   -   5        $ CPU_bar��5      $
��Left=�6'   $��20��6B   $��
289,10,0,0q�6N   $	��Top=�6b   $	��122��6z   �� 5   
   $
��Left=�6   $��18��6/   $��
289,11,0,0q�6;   $
��Wrap=�6O   $��
CPU usage:��6c   $	��Top=�6u   $��63��6�   �� 5   
   $
��Left=�6   $��
138,11,0,0q�6/   $
��Wrap=�6C   $��
RAM Usage:��6W   $	��Top=�6i    J� RenderTransformOrigin$ -0.571,0&�6�   $��19��6�   �� 5   
   -   5        	 ��Name$	 Ram_use��5      $
��Left=�6%   $��19��6@   $��
207,11,0,0q�6L   $
��Wrap=�6`   $��0%��6t   $	��Top=�6~   $��53��6�   $ 2.237,-6.684&�6�   �� 5   
   -	   5        $	 CPU_percent��5      $
��Left=�6)   $��
352,11,0,0q�6D   $
��Wrap=�6X   $��0%��6l   $	��Top=�6v   $��19��6�   $��59��6�   5      5      