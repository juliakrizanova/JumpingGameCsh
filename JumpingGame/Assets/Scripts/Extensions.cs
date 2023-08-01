using UnityEngine;

public static class Extensions
{
    // Extension method to perform a raycast from the Rigidbody2D in a specified direction,
    // considering objects only on the given LayerMask.
    // If the Rigidbody2D is kinematic (not controlled by physics), the method returns false.
    // The raycast is performed using a circle with a defined radius and distance from the Rigidbody2D's position.
    // Returns true if the raycast intersects with an object on the given LayerMask (excluding itself).
    // Otherwise, it returns false.
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction, LayerMask layerMask)
    {
        if (rigidbody.isKinematic)
        {
            // The Rigidbody2D is currently kinematic, meaning the physics is not controlling it.
            // Therefore, it will not perform any raycasting, and the method returns false.
            return false;
        }

        // Define the radius and distance for the circle cast.
        float radius = 0.25f;
        float distance = 0.48f;

        // Perform the 2D circle cast in the specified direction from the Rigidbody2D's position.
        // The method checks for intersections with objects on the given LayerMask.
        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction.normalized, distance, layerMask);

        // Check if the circle cast hit an object (excluding itself, if applicable).
        // Return true if an intersection is found, and the object hit is not the same Rigidbody2D.
        return hit.collider != null && hit.rigidbody != rigidbody;
    }

    // Extension method to perform a dot product test between the direction from "transform" to "other"
    // and a specified test direction.
    // The method calculates the direction vector from "transform" to "other" and normalizes it.
    // It then performs a dot product between the normalized direction and the test direction.
    // The method returns true if the dot product result is greater than 0.25f (indicating an angle greater than 75 degrees),
    // which means the objects are facing approximately in the same direction.
    // Otherwise, it returns false, indicating that the objects are facing away from each other.
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        // Calculate the direction vector from "transform" to "other".
        Vector2 direction = other.position - transform.position;

        // Normalize the direction vector to make it a unit vector.
        direction.Normalize();

        // Perform a dot product between the normalized direction and the specified test direction.
        // The dot product measures the cosine of the angle between the two vectors.
        // If the result is greater than 0.25f, it indicates an angle greater than 75 degrees,
        // and the objects are considered to be facing approximately in the same direction.
        return Vector2.Dot(direction, testDirection) > 0.25f;
    }
}
