   M S B A M L   `   `   `  ����N  JTowam - projekt (1), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Towam___projekt__1_Towam___projekt__1_  5   	   "    Towam___projekt__1_.Register   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aGmaterialDesign11http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Towam___projekt__1_     5   	     � Title$  Register��5	   	   $	��450��6   $	��800��6'   .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��400 �6   6-   �� 5      $	��400 �6   6-   .+�5   
   �� $��1��6   $��Images/kasa.jpg��6    $��UniformToFill=�69   6S   �� 5   
   $��Center=�6   $��Center=�60    �� Orientation$ Vertical=�6M   .+�5      �� $��Register Page��6   $��36(�6-   6=   �� 5      $ 
Horizontal=�6   .+�5      ��  �� CornerRadius$ 25 25 25 25��6   $	��300��64   $��50��6@   
�������._�5      �� -   5         ��Name$ username��5      $	��250��60   $�� ��6<   
�������$��20(�6V   6f   5      �� 5      $	��100��6   6+   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ Account=�6+   $��30��6:   $��50��6E   $�� 0 25 25 25q�6Q   5      �� 5      $ 
Horizontal=�6   .+�5      �� $ 25 25 25 25��6   $	��300��64   $��50��6@   
�������._�5      G� -   5         G�Name$ password��5   "   $	��250��65   
�������$��20(�6S   6c   5        5      $ Password=�6+   $��30��6;   $��50��6F   6T   5      �� 5      $��40��6   6&   �� 5       $ 
Horizontal=�6   .+�5!      �� -   5         ��Name$ Register_Btt��5!      $��Register��6/   $	��200��6B   $��50��6N   
���   �6�   �� 5"      -   5        $ Back_Btt��5"      $
��Back��6+   $	��200��6:   $��50��6F   
���   �6~   5#      5%      5&      5'      