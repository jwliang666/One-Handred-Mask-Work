using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Meant to be a component of a camera
public class CameraSupport : MonoBehaviour
{
    private Camera mTheCamera;   // Will find this on the gameObject
    private Bounds mWorldBound;  // Computed bound from the camera

    public Transform target; // 要跟随的目标对象（人物）
    public float smoothSpeed = 0.125f; // 相机跟随的平滑度

    public float zoomSpeed = 50f; // 缩放速度
    public float minSize = 1f; // 最小视角大小
    public float maxSize = 10f; // 最大视角大小

    public enum WorldBoundStatus
    {
        Outside = 0,
        CollideLeft = 1,
        CollideRight = 2,
        CollideTop = 4,
        CollideBottom = 8,
        Inside = 16
    };

    // Start is called before the first frame update
    void Awake()  // camera may be disabled by some in Start(), so init in Awake.
    {
        mTheCamera = gameObject.GetComponent<Camera>();
        Debug.Assert(mTheCamera != null); // if this is null, then, the script is not on a Camera and nothing works

        Debug.Log("Camera Start:" + gameObject.name);

        #region bound support
        mWorldBound = new Bounds();
        UpdateWorldWindowBound();
        #endregion
    }

    void Update()
    {
        UpdateWorldWindowBound();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Quit();
        }
        if (Input.GetKey(KeyCode.U))
        {
            ZoomCamera(-zoomSpeed * Time.deltaTime);
        }

        // 减小视角
        if (Input.GetKey(KeyCode.I))
        {
            ZoomCamera(zoomSpeed * Time.deltaTime);
        }
    }

    public Bounds GetWorldBound() { return mWorldBound; }

    #region bound support

    private void UpdateWorldWindowBound()
    {
        // get the main 
        if (null != mTheCamera)
        {
            float maxY = mTheCamera.orthographicSize;
            float maxX = mTheCamera.orthographicSize * mTheCamera.aspect;
            float sizeX = 2 * maxX;
            float sizeY = 2 * maxY;

            // Make sure z-component is always zero
            Vector3 c = mTheCamera.transform.position;
            c.z = 0.0f;
            mWorldBound.center = c;
            mWorldBound.size = new Vector3(sizeX, sizeY, 1f);  // z is arbitrary!!
        }
    }

    // Cannot use the regular bounds intersect() and contains() function
    // Because we are not using the Z-values 
    private bool BoundsIntersectInXY(Bounds b1, Bounds b2)
    {
        return (b1.min.x < b2.max.x) && (b1.max.x > b2.min.x) &&
               (b1.min.y < b2.max.y) && (b1.max.y > b2.min.y);
    }

    private bool BoundsContainsPointXY(Bounds b, Vector3 pt)
    {
        return ((b.min.x < pt.x) && (b.max.x > pt.x) &&
                (b.min.y < pt.y) && (b.max.y > pt.y));
    }

    public WorldBoundStatus CollideWorldBound(Bounds objBound, float region = 1f)
    {
        WorldBoundStatus status = WorldBoundStatus.Outside;
        Bounds b = new Bounds(transform.position, region * mWorldBound.size);

        if (BoundsIntersectInXY(b, objBound))
        {
            if (objBound.max.x > b.max.x)
                status |= WorldBoundStatus.CollideRight;
            if (objBound.min.x < b.min.x)
                status |= WorldBoundStatus.CollideLeft;
            if (objBound.max.y > b.max.y)
                status |= WorldBoundStatus.CollideTop;
            if (objBound.min.y < b.min.y)
                status |= WorldBoundStatus.CollideBottom;
            // not testing Z anymore!! if ((objBound.min.z < mWorldBound.min.z) || (objBound.max.z > mWorldBound.max.z))

            if (status == WorldBoundStatus.Outside)  // intersects and no bounds touch ==> Inside!
                status = WorldBoundStatus.Inside;
        }

        return status;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // 计算目标对象的位置
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // 使用 SmoothDamp 函数使相机位置平滑过渡到目标位置
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // 设置相机的位置为平滑后的位置
            transform.position = smoothedPosition;
        }
    }



    void ZoomCamera(float increment)
    {
        Camera mainCamera = GetComponent<Camera>(); // 获取相机组件
        if (mainCamera != null)
        {
            // 调整相机的视角大小
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize + increment, minSize, maxSize);
        }
        else
        {
            Debug.LogWarning("No Camera component found on this object.");
        }
    }

    void Quit()
    {
        // 退出游戏
        Application.Quit();
    }

    #endregion
}