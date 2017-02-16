//Korean===================================================================================
[ ������ ���� ]
���� : �̻��
e-mail : lswsox@gmail.com

[ ��� ]
- ���� �������� �����Դϴ�
- �پ��� ���� ���� �����մϴ�
- Ease-in �� Ease-out ���� ����� ������ �� �ֽ��ϴ�
- ������Ʈ�� �ڽ����� �����ϸ� ������Ʈ�� �̵��̳� ȸ���� �ݿ��� �� �ֽ��ϴ�
- ������ trail ���� ������ ���ϸ� ������ �ڵ� ���ŵ˴ϴ�
- �ұ�Ģ������ ��鸮�� Ziggle Move Ư���� ������ �� �ֽ��ϴ�.

[ ���� ���ǻ��� ]
�� ��ũ��Ʈ�� ����Ƽ Trail Renderer�� ����մϴ�.
Trail Renderer�� ���� �ӵ��� ��ü�� ������ ��� �����Ÿ��� Flickering ������ �߻��մϴ�.
Spiral Emitter �� ���� ��ġ�� �����Ͻ� �� Trail�� ������ ���� �ӵ��� ������ �� �ֵ��� ���ּ���
�����̴� Flickering ������ ������ Min Vertex Distance ���� �ٿ������ν� ������ �� �ֽ��ϴ�.

������ SP-Move > SP-Rotate > SP-Distance �� Min Vertex Distance ���� ���� �����ϰ� �����ִ� ���Դϴ�.
�� ���� �����Ϳ��� ������ ���� ���� �����ؾ߸� �ϴ� ���Դϴ�.
�� ���� ����ġ�� ������ ���ɿ� �ǿ����� ��ĥ �� ������ ����Ʈ ���� 0.1 �Դϴ�.
�� ���� �����ϴ� ��� :
SP-Move �������� ���� ��ġ�� �� SP-Distance ����� Min Vertex Distance ���� ������ �� Prefab Apply

�����մϴ�.

//English===================================================================================
[ Developer ]
Name : Lee Sang-won
e-mail : lswsox@gmail.com

[ Features ]
- Spiral movement with TrailRenderer
- Many random properties
- Select Ease-in and Ease-out interpolation
- Child to object and Constrint to object (Move, Rotation)
- Auto-destruct generated trails
- Ziggle Move

[ Attention ]
This script uses Trail Renderer of Unity 3D.
Trail Renderer have flickering problem when head objects move slow.
You should keep speed enough to avoid flickering problem when edit parameters of Spiral Emitter.
Flickering issues can be improved by reducing the next "Min Vertex Distance" value.

"Min Vertex Distance" value is related to the scale of the scene
(SP-Move > SP-Rotate > SP-Distance)
This is a value that must be modified directly in the editor by user
If this value is too small, there is a negative impact on performance
The default value is 0.1
To modify this value:
After placing the SP-Move prefab on the scene,
fix the "Min Vertex Distance" value of node SP-Distance,
Press Inspector > Prefab > Apply


Thank you.