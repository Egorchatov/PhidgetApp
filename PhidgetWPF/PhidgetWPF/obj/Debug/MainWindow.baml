   M S B A M L   `   `   `  ����  
PhidgetWPF    PhidgetWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Digital Output��5   	   $	��400��6    $	��525��6-    � WindowStartupLocation$ CenterScreen=�69    � WindowStyle$ SingleBorderWindow=�5   	    � 
ResizeMode$ NoResize=�6*   .��5      �  � RowDefinitions 5   
   �� 5      $	��120 �6   �� 5	      $	��250 �6   .+�5   
   �� $��0��6   $��Phidget info��6    $��12, 0q�66   .��5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��
Attached: ��6    $	��5,5q�62   �� 5      $��Nothing��6    $	��0,5q�6/   5      �� 5      $ 
Horizontal=�6   .+�5      �� 
���������63   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType" �	 �� Path$	 ActualWidth�5      �� 5      $ 
Horizontal=�6   .+�5      �� $��	Version: ��6    $	��5,5q�61   �� 5      $
��70,5q�6L   ��6    �� *Test+
 �� FallbackValue$
 Defaul��6L   5      �� 5      .+�5      �� $��	Channel: ��6    $	��5,5q�61   5      5      5      �� 5   
   $��1��6   $��Settings��6    $��12, 5q�62   .��5       �� .+�5!      �� $	��100��6   $��30��6%   $��Turn On��61   ��6C   �� *TurnOnCommand+�� 5"      $��
Duty Cycle��6   $
��5,10q�6.   �� 5#       � Minimum$ 0Q�6    � Maximum$	 100Q�6%    �� TickPlacement$ BottomRight=�6K    �� TickFrequency$ 5Q�6g   $��0,0,0,30q�6y    � Value 63   �� *Value+6y   �� 5$      $ 
Horizontal=�6   .+�5%      �� $��Forward Voltage: ��6    $	��5,0q�69   $��Center=�6F   �� 5&      $��70��6   $��20��6*   $��Center=�66   �� 5'      $ Vertical=�6!   .+�5(      �� $��Current Limit��6$   $��
40,0,200,0q�69   �� 5)      $	 100Q�6!   $ BottomRight=�6/   $ 5Q�6K   $��40,0,0,0q�6]   5*      5+      5,      5-      5.      5/      