   M S B A M L   `   `   `  ����N  JTowam - projekt (1), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Towam___projekt__1_Towam___projekt__1_  5   	   !    Towam___projekt__1_.Window1   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:Towam___projekt__1_     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Window1��5	   	   $	��450��6   $	��800��6&   .��5
      � .+�5   
   #  MaterialDesignThemes.Wpf.Card  $
��Left=�6   $	��420��69   $	��Top=�6F   $	��132��6^   ���	#FFA200FF6j   �� 5   
   -   5         ��Name$ lblSavingsName��5      $��Nazwa celu:��6(   $
��Left=�6>   $��540,116,0,264q�6Y   �� 5   
   -   5        $ lblSavingsAmount��5      $��Kwota celu:��6*   $
��Left=�6@   $��540,10,0,376q�6[   �� 5   
   -   5        $ labelGoalName��5      $�� ��6'   $	��100��62   $��181,27,512.6,362q�6>   �� 5   
   -   5         ��Name$ txtSavingsAmount��5      $
��Left=�6,   $	��200��6H   $��538,44,0,327q�6T   �� 5   
   -   5        $ txtSavingsName��5      $
��Left=�6*   $	��200��6F   $��538,156,0,223q�6R   � 5   
   -   5         �Name$ progressBar��5      $
��Auto��6,    � Minimum$ 0Q�6:    � Maximum$	 100Q�6F   $��173,63,297.6,307q�6T    � Value 6n   �� *ProgressPercentage+��5      �� 5       �� 
TargetType" �6    �� Triggers 5      �� 5      	 �� Binding	 6&   �� *ProgressPercentage+
 �� Value
 1006M   .a�5      ��  �� Property � �� �� Value
 � � �6;   5      �� 5      	 6&   �� *ProgressPercentage+
 756M   .a�5      ��  � ��
 � ���6;   5      �� 5      	 6&   �� *ProgressPercentage+
 506M   .a�5      ��  � ��
 � ���6;   5      �� 5      	 6&   �� *ProgressPercentage+
 256M   .a�5       ��  � ��
 �  ��6;   5!      5#      5%      �� 5&   
   -   5         ��Name$ txtProgressPercentage��5&      $��Center=�6}   $	��100��6�   $��20��6�   $��Center=�6�   $��344,73,349.6,327q�6�    �� TextAlignment$ Center=�6�   ��63   ��  �� ElementName$ progressBar�� �� Path$ Value� �� StringFormat$
 {0}%��6�   �� 5'   
   -   5        $ 
txtSavings��5'      $!��Podaj kwotę oszczędności��6&   $��509,262,133.6,120q�6F   �� 5(   
   -	   5         ��Name$ 	btnUpdate��5(      $��Update Progress��6$   $��173,185,297.6,203q�6V   �� 5)   
   -
   5        $ btnAddSavings��5)      $��	Dodaj cel��6(   $
��Left=�6X   $��20,99,0,289q�6s   �� 5*   
   -   5        $��Button��5*      $
��Left=�6"   $��206,364,0,0q�6=   $	��Top=�6R   $��75��6j   6u   5/      50      