   M S B A M L   `   `   `  ����B  >Example, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ExampleExample  5   	       Example.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Example     5   	     � Title$"  Запись на прием��5   	   $	��450��6!   $	��800��6.   .��5	      �  � RowDefinitions 5
   
   �� 5      $�� auto �6   6/   �� 5      $��* �6   6-   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��Center=�6K   .+�5      �� $"�� Специализация:��6      BlockCommon#��[  6/   $
��Auto��6T   6d   �� 5      -   5        $��ComboSpecialisation��5       �� DisplayMemberPath$
 Name��63   6�   �� 5      $��
 Врач:��6   #��[  6&   $
��Auto��6K   6Z   �� 5      -   5        $��ComboDoctor��5      $ FullName��6*   6z   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGridSchedule��5      $��1��6*      SelectionUnit$
 Cell=�67   5      5      5      