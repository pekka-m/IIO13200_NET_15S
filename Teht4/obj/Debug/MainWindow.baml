   M S B A M L   `   `   `  ����@  <Teht4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Teht4Teht4  5   	       Teht4.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Teht4     5   	     � Title$  
MainWindow��5   	   $	��600��6   $	��420��6)   .��5	      � .+�5
   
   �� -   5        $��
Hae viinit��5
      $��16(�6&   $	��150��64   $��30��6@   $	��Top=�6L   $
��Left=�6d   $��10q�6   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGViinit��5         AutoGenerateColumns .  $��10 50 10 10q�6m   ��6A   ��  �� Path$ Elements[wine]�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Nimi��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� $ Element[nimi].Value�  5      $	 Maa��6%    62   �� $ Element[maa].Value�  5      $ Arvio��6%    64   �� $ Element[arvio].Value�5      �� 5   
   -   5         ��Name$ comboBox��5      $��16(�6%   $
��Left=�63   $��
173,10,0,0q�6N   $	��Top=�6b   $	��229��6z   $��30��6�   5      5      