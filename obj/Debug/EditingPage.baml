   M S B A M L   `   `   `  ����D  @Culteries, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Culteries	Culteries  5   	       Culteries.EditingPage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Culteries     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$/ )Редактирование товара��5	   	   $	��512��6'   $	��600��64   .��5
      ��  �� Padding$ 24q�6   ._�5   
   �� $��Center=�6   $��Bottom=�62    � 	Resources 5       �� 
TargetType �� Property �� Value��%[   '��       �� 5      " ��6   .�5      ��  � ��$ 0, 12, 0, 0q�6/   5      5      .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $ ��Наименование: ��6   $	��150��61   �� 5      -   5         ��Name$ NameTextBlock��5   &   $	��300��6   6&   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Категория: ��6   $	��150��6.   �� 5      -   5        	 ��Name$	 CategoryComboBox��5   '   $	��300��6   
 �� DisplayMemberPath$

 name��6A   5      �� 5      $ 
Horizontal=�6   .+�5      �� $.��(Количество на складе: ��6   $	��150��69   �� 5      -   5        $ QuantityTextBlock��5   &   $	��300��6   6&   5      �� 5       $ 
Horizontal=�6   .+�5!      �� $��Поставщик: ��6   $	��150��6.   �� 5"      -   5        $	 ProviderComboBox��5"   '   $	��300��6   $

 name��6A   5#      �� 5%      $ 
Horizontal=�6   .+�5&      �� $'��!Стоимость товара: ��6   $	��150��65   �� 5'      -   5        $ CostTextBlock��5'   &   $	��300��6   6&   5(      �� 5*      $ 
Horizontal=�6   .+�5+      �� $��Описание: ��6   $	��150��6-   �� 5,      -   5        $ DescriptionTextBlock��5,   G   $	��300��6   $	��125��6&    �� TextWrapping$
 Wrap=�63   6G   5-      � 55      .+�56      �� -   5        $��Изменить��56      $��0, 64, 0, 0q�6,   $
��Left=�6A   $��Bottom=�6\   $��24��6w   $	��200��6�      AccentColor#��[  6�   ���#fff6�   �� 57      -   5        $��
Назад��57      $��24��6)   $	��200��65   $��Right=�6A   $��Bottom=�6]   #��[  6x   ���#fff6�   58      59      5:      5;      