   M S B A M L   `   `   `  ����G  CWpfTreeView4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfTreeView4WpfTreeView4  5   	       WpfTreeView4.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfTreeView4     5   	     � Title$  
MainWindow��5   	   $	��700��6   $
��1100��6)   .��5	      �  � RowDefinitions 5   
   �� 5      �� 5      $	��150 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $	��150 �6#   �� 5      .+�5      � $��0��6   .+�5      R� -   5        $��	treeView1��5      $��0��6,   ��5      �� 5       �� ItemsSource 63   ��  �� Path$ Nodes�.R�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5   "   �� ��6(   �� $ 	ImageName��� 5   "   $
��Bold"�6(   ��6:   �� $ fileName�5       5"      5$      5%      � 5&      $��1��6   .+�5'      �� -   5        $��	ListView1��5'      ��5(      �� 5)      .R�5*      �� $ 
Horizontal=�6)   .+�5+   "   �� $��Center=�6D   ��6(   �� $	 img�6D   �� 5,      $
��Bold"�6%   $��Center=�6U   ��67   �� $
 Name�6U   5-      5.      59      5:      � 5<      $��2��6   .+�5B      �� -   5        $��ImageBig��5B      5C      5D      5E      � 5G   
   $��1��6   .+�5H      �� -   5        $��
ImageSmall��5H      ��5J      �� 5K      .R�5L      �  � Orientation$ 
Horizontal=�6$   5M      ��5O      �� 5P      .R�5Q      � -   5        $	��200��5Q      $	��150��6+   
 � Tag 6U   �� $ imgPath� 5R      �� 5S   "   .+�5U      �� $��0��6$   $��Uniform=�6Q   ��61   �� $ imgPath�6Q   5V      5W      5Z      5[      5\      5^      