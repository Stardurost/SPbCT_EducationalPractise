   M S B A M L   `   `   `  ����A  =Fitnes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:FitnesFitnes  5   	       Fitnes.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Fitnes     5   	     � Title$,  &Запись на тренировку��5   	   $	��450��6&   $	��800��63   ���#1a1a1a.��5	      � ���#1a1a1a � RowDefinitions 5
   
   �� 5      $�� auto �6   6.   �� 5      $��* �6   6*   .+�5   
   �� ���#1a1a1a �� Orientation$ 
Horizontal=�6+   $��Center=�6D   $��Center=�6a   $	��435��6|   .+�5      �� ���#1a1a1a$�� Тренер:��6-      BlockCommon#��[  6=   $
��auto��6c   
����� �6�   �� 5      -   5        $��ComboTrainer��5   -   ���#1a1a1a �� DisplayMemberPath$
 Name��6A   $	��350��6�   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGridSchedule��5      $��1��6*      SelectionUnit$
 Cell=�67   $
��auto��6L   ���#1a1a1a���#1a1a1a5      5      5      