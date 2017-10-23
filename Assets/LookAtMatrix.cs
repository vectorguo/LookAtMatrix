using UnityEngine;

public class LookAtMatrix : MonoBehaviour
{
    public GameObject TargetPoint;

	void Start ()
	{
        //使Z轴指向目标点
	    var dirZ = TargetPoint.transform.position - transform.position;
        dirZ.Normalize();

        //计算x轴方向y * z = x
        var dirX = Vector3.Cross(Vector3.up, dirZ);
        dirX.Normalize();

        //计算y轴方向z * x = y
	    var dirY = Vector3.Cross(dirZ, dirX);
        dirY.Normalize();

        //计算从世界坐标变化到LookAt坐标系的矩阵
        Matrix4x4 lookAt = new Matrix4x4();
        lookAt.SetColumn(0, new Vector4(dirX.x, dirX.y, dirX.z, 0));
	    lookAt.SetColumn(1, new Vector4(dirY.x, dirY.y, dirY.z, 0));
	    lookAt.SetColumn(2, new Vector4(dirZ.x, dirZ.y, dirZ.z, 0));
	    lookAt.SetColumn(3, new Vector4(0, 0, 0, 1));

        //计算最终矩阵
        var finalMatrix = lookAt * transform.localToWorldMatrix;
        Debug.Log(finalMatrix);

	    transform.LookAt(TargetPoint.transform.position);
	    Debug.Log(transform.localToWorldMatrix);
    }
}
