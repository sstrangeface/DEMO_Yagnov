   M S B A M L   `   `   `  ����A  =DemoEx, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DemoExDemoEx  5   	       DemoEx.DataGrid   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:DemoEx     5   	     � Title$  DataGrid��5   	   $	��450��6   $	��800��6'   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��27* �6   �� 5      $��5* �6    � RowDefinitions 5   
   �� 5      �� 5      $��80 �6   .+�5   
   � $��0��6   $��1��6    5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5      �� -   5         ��Name$ 	AddButton��5   "   $��0��6   $��ДОБАВИТЬ��66   6I   �� 5      -   5        $ 
EditButton��5   "   $��1��6   $ ��РЕДАКТИРОВАТЬ��67   6O   �� 5      -   5        $ 	DelButton��5   "   $��2��6   $��УДАЛИТЬ��66   6H   �� 5       -   5        $ 	ExpButton��5    "   $��3��6   $"��ЭКСПОРТИРОВАТЬ��66   6O   �� 5!      -   5        $ 
ExitButton��5!   "   $��7��6   $��
ВЫХОД��67   6G   5"      &   System.Windows.Controls.DataGrid  5#   
   -   5          Name$ ProductsDataGrid��5#         AutoGenerateColumns .     
IsReadOnly . $��0��6[   $��0��6k      Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6O   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *	ProductID+6O     5&      $ Название��6%   $	 * 6W   
 67   �� *ProductName+6W     5'      $ Цена��6%   $
	 Auto 6M   
 63   �� *Price+6M     5(      $ Описание��6%   $	 * 6W   
 67   �� *Description+6W   5*      5+      5,      