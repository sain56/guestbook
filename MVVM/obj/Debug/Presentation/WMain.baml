   M S B A M L   `   `   `  ����  MVVM    MVVM.Presentation.WMain   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $��w��5   >     � Title$  Gästebuch .comspace��6	   $	��600��6%   $	��800��62   .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� -   5        $��c_stack_main��5      .+�5   
   �� $ 
Horizontal=�6   .+�5      �� $��25��6   $��50��6!   $	��Add��6,   $��5q�6:   ��5      �� *	p_cmd_add+��63   ��  �� ElementName$ w���� 5      $��25��6   $��50��6!   $
��Edit��6,   $��5q�6;   ��5      �� *
p_cmd_edit+��64   �� $ w���� 5      $��25��6   $��50��6!   $��Remove��6,   $��5q�6=   ��5      �� *p_cmd_remove+��66   �� $ w��5      �� 5   
   -   5        $��c_TabControl��5   H   $
��Left=�6   $	��Top=�60   .@�5      �� $��	Einträge��6   .��5      �� $ Vertical=�6   $	��800��64   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ c_dg_departments��5         AutoGenerateColumns .     
IsReadOnly . "   VerticalScrollBarVisibility$
 Auto=�5      $   HorizontalScrollBarVisibility$
 Auto=�6B      SelectionMode$ Extended=�5      ��5   9   �� 	 �� Path$	 p_departments�
 �� UpdateSourceTrigger$
 PropertyChanged=� �� SelectedItem 5      �� *p_selectedMessage+ J� InputBindings 5      d� 5   "    d� Gesture$ LeftDoubleClicka�6/    �� Command 6I   �� *
p_cmd_dc+ �� CommandParameter 6f   �� $ w��6�      Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *p_name+6L     5#   "   $ 	Nachricht��6S      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6f    65   �� *	p_message+6v     5$   "   $ Datum��6P   $	 200 6_    65   �� *p_date+6o   5'      5(      5)      5,      5.      �� 50   
   -   5        $��c_stack_form��50      $y�	Collapsed=�6)   53      54      