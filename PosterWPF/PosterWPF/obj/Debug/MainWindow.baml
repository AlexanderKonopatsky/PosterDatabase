   M S B A M L   `   `   `  ����D  @PosterWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PosterWPF	PosterWPF  5   	       PosterWPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PosterWPF     5   	   -   5          �Name$  Poster��5   	    � Title$ Poster��5   	   $	��670��6   $	��850��6%    � 
ResizeMode$ NoResize=�61    � WindowStartupLocation$ CenterScreen=�6u   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��15* �6   �� 5      $
��242* �6   .+�5   
   � $
��Left=�6   $��55��6*   ���#86ddb0$	��Top=�6K   $	��844��6c   $��2��6o   .+�5      �� 
���   �$��1q�6)   �� 5      -   5         ��Name$ Section��5      $��Films��6%   $
��Left=�65   $��	519,2,0,0q�6P   $	��Top=�6c   $	��151��6{   $��53��6�   ���	#FFA02525$��36(�6�   $��Times New Roman)�6�    J� RenderTransformOrigin$ 	0.5,0.435&�6�   5      �� 5   
   -   5         ��Name$
 Menu��5       K� ZIndex$ 3��6#   $
��Left=�64   $	��641��6O   $	��Top=�6\   $	��297��6t   ���#6f9679$��2��6�   $ 0.478,0.554&�6�   .+�5      �� -   5        	 ��Name$	 SearchButton��5      $��Search��6+   $��55��6<   ���#496645
�������$��18(�6p      SearchButtonStyle#���   6�   �� 5      -   5        $	 FilmsButton��5      $��Films��6*   $��0,1,0,1q�6:   $��Center=�6T   $��88��6x   ���#184223
�������$��22(�6�     ButtonsStyle#���  6�   6�   �� 5      -   5        $	 ConcertsButton��5      $��Concerts��6-   $��0,0,0,0q�6@   $��Center=�6Z   $��88��6~   ���	#FF212020���#184223
�������$��22(�6�   #���  6�   6�   �� 5      -   5        $	 SettingsButton��5      $��Settings��6-   $��0,1,0,1q�6@   $��Center=�6Z   $��88��6~   ���#184223
�������$��22(�6�   #���  6�   6�   5      � 5   
   -   5        
 �Name$
 MainBody��5      $
��Left=�6!   $	��566��6>   $��1��6K   $	��Top=�6X   $	��524��6p   $��
310,28,0,0q�6|    � ColumnDefinitions 5      �� 5      �� 5       $��0* �6#   5"      � 5#   
   -	   5        $
 OpenCalendar��5#      $ 3��6%   $
��Left=�66   $	��255��6Q   $��
10,318,0,0q�6^   $��1��6r   $	��Top=�6   $	��275��6�   5%      5&      