   M S B A M L   `   `   `  ����U  QProjekat_B-Dnevnik_ishrane, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:Projekat_B_Dnevnik_ishrane.views Projekat_B_Dnevnik_ishrane.views  5   	   6    0Projekat_B_Dnevnik_ishrane.views.FoodStuffWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:Projekat_B_Dnevnik_ishrane.views     5   	      WindowStyle#��[  5   
     � WindowStartupLocation$  Manual=�5	   	   
 � Top$ 0��5
   	    � Left$	 300��5   	    � 
ResizeMode$ NoResize=�6    � Title$ FoodStuffWindow��5   	   $��565.909��6!   $	��800��62   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridFoodStuff��5   ,      HeadersVisibility$
 None=�6   $
��Left=�6G   $	��290��6b   $��
47,144,0,0q�6o   $	��Top=�6�   $	��690��6�      AutoGenerateColumns .  ���	#FFFEEBBB   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	Namirnica��6&   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ��  �� Path$ 	Namirnica�6^   4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 Izaberi��6)      CellTemplate 5      �� 5      .R�5      �� $��btnAdd��6%   -   5        $��Izaberi��5   3   6E   5      5      5      �� 5      -   5         ��Name$ searchTextBox��5      $	��Top=�6K   ���	#FFFEEBBB$��275,25,249.6,0q�6z   $��64��6�   �� 5   
   -   5        $
��Left=�5   +   $��34��6F   $��
486,41,0,0q�6R   $	��Top=�6f   $��41��6~    J� RenderTransformOrigin$ 0.439,0.144&�6�   ��5      �� 5       �� ImageSource$ 
search.png��6   5      �� 5    
   -   5        $
��Left=�5    +   $��48��6F   $��	47,41,0,0q�6R   $	��Top=�6e   $��55��6}   $ 0.548,1.204&�6�   ��5!      �� 5"      $ left-arrow3.png��6   5$      �� 5%   
   -   5        $ watermarkSearchTextBox��5%   <   $
��Left=�6]   $��64��6x   $��
275,25,0,0q�6�    �� TextWrapping$
 Wrap=�6�     searchTextBox#���  6�   $	��Top=�6�   $	��269��6�   ���	#FFFEEBBB6�   5&      5'      