using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleEffectSystems : MonoBehaviour
{

    public void Start()
    {
     
    }

    public void Update()
    {
        
    }

    #region Small enemies PIECES
    public void SmallEnemyPieces(Vector2 pos, float size)
    {
        Choises.maxBrokenPieces += 1;
        GameObject pieces = ObjectPool.instance.GetSmallEnemyPiecesFromPool();
        pieces.transform.localScale = new Vector2(size, size);
        StartCoroutine(SetPiecesInactive(pieces));
        pieces.transform.position = pos;

        Transform[] childTransforms = new Transform[]
           {
            pieces.transform.Find("Broken1"),
            pieces.transform.Find("Broken2"),
            pieces.transform.Find("Broken3"),
            pieces.transform.Find("Broken4"),
            pieces.transform.Find("Broken5"),
            pieces.transform.Find("Broken6"),
            pieces.transform.Find("Broken7"),
            pieces.transform.Find("Broken8")
           };

        foreach (Transform childTransform in childTransforms)
        {
            childTransform.gameObject.SetActive(false);
            childTransform.gameObject.transform.position = pieces.transform.position;
        }

        int numPiecesToActivate = Random.Range(2, 5);
        HashSet<int> chosenIndices = new HashSet<int>();

        while (chosenIndices.Count < numPiecesToActivate)
        {
            int randomIndex = Random.Range(0, childTransforms.Length);
            chosenIndices.Add(randomIndex);
        }

        foreach (int index in chosenIndices)
        {
            Transform selectedTransform = childTransforms[index];
            selectedTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            Image imageComponent = selectedTransform.GetComponent<Image>();
            if (imageComponent != null)
            {
                Color originalColor = imageComponent.color;
                imageComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Set alpha to 1
            }

            selectedTransform.gameObject.SetActive(true);

            Rigidbody2D rb = selectedTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(forceDirection * Random.Range(80f, 850f)); 
            }
        }
    }

    IEnumerator SetPiecesInactive(GameObject pieces)
    {
        float randomTime = Random.Range(20, 28);
        yield return new WaitForSeconds(randomTime);

        // Assuming Image component is used for fading (replace with the actual component type)
        Image[] imageComponents = pieces.GetComponentsInChildren<Image>();

        float fadeDuration = 4f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            foreach (Image imageComponent in imageComponents)
            {
                Color currentColor = imageComponent.color;
                imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha is completely faded out
        foreach (Image imageComponent in imageComponents)
        {
            Color currentColor = imageComponent.color;
            imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);
        }

        Choises.maxBrokenPieces -= 1;
        ObjectPool.instance.ReturnEnemySmallPiecesFromPool(pieces);
    }
    #endregion

    #region Shooting enemies PIECES
    public void ShootingEnemyPieces(Vector2 pos, float size)
    {
        Choises.maxBrokenPieces += 1;
        GameObject pieces = ObjectPool.instance.GetShootingEnemyPiecesFromPool();
        pieces.transform.localScale = new Vector2(size, size);
        StartCoroutine(SetShootingPiecesInactive(pieces));
        pieces.transform.position = pos;

        Transform[] childTransforms = new Transform[]
           {
            pieces.transform.Find("Piece1"),
            pieces.transform.Find("Piece2"),
            pieces.transform.Find("Piece3"),
            pieces.transform.Find("Piece4"),
            pieces.transform.Find("Piece5"),
            pieces.transform.Find("Piece6"),
            pieces.transform.Find("Piece7"),
            pieces.transform.Find("Piece8")
           };

        foreach (Transform childTransform in childTransforms)
        {
            childTransform.gameObject.SetActive(false);
            childTransform.gameObject.transform.position = pieces.transform.position;
        }

        int numPiecesToActivate = Random.Range(2, 5);
        HashSet<int> chosenIndices = new HashSet<int>();

        while (chosenIndices.Count < numPiecesToActivate)
        {
            int randomIndex = Random.Range(0, childTransforms.Length);
            chosenIndices.Add(randomIndex);
        }

        foreach (int index in chosenIndices)
        {
            Transform selectedTransform = childTransforms[index];
            selectedTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            Image imageComponent = selectedTransform.GetComponent<Image>();
            if (imageComponent != null)
            {
                Color originalColor = imageComponent.color;
                imageComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Set alpha to 1
            }

            selectedTransform.gameObject.SetActive(true);

            Rigidbody2D rb = selectedTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(forceDirection * Random.Range(80f, 850f));
            }
        }
    }

    IEnumerator SetShootingPiecesInactive(GameObject pieces)
    {
        float randomTime = Random.Range(30, 35);
        yield return new WaitForSeconds(randomTime);

        // Assuming Image component is used for fading (replace with the actual component type)
        Image[] imageComponents = pieces.GetComponentsInChildren<Image>();

        float fadeDuration = 4f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            foreach (Image imageComponent in imageComponents)
            {
                Color currentColor = imageComponent.color;
                imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha is completely faded out
        foreach (Image imageComponent in imageComponents)
        {
            Color currentColor = imageComponent.color;
            imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);
        }

        Choises.maxBrokenPieces -= 1;
        ObjectPool.instance.ReturnShootingEnemyPiecesFromPool(pieces);
    }
    #endregion

    #region Big enemies PIECES
    public void BigEnemyPieces(Vector2 pos, float size)
    {
        Choises.maxBrokenPieces += 1;
        GameObject pieces = ObjectPool.instance.GetBigPiecesFromPool();
        pieces.transform.localScale = new Vector2(size, size);
        StartCoroutine(SetBigPiecesInactive(pieces));
        pieces.transform.position = pos;

        Transform[] childTransforms = new Transform[]
           {
            pieces.transform.Find("Piece1"),
            pieces.transform.Find("Piece2"),
            pieces.transform.Find("Piece3"),
            pieces.transform.Find("Piece4"),
            pieces.transform.Find("Piece5"),
            pieces.transform.Find("Piece6"),
            pieces.transform.Find("Piece7"),
            pieces.transform.Find("Piece8")
           };

        foreach (Transform childTransform in childTransforms)
        {
            childTransform.gameObject.SetActive(false);
            childTransform.gameObject.transform.position = pieces.transform.position;
        }

        int numPiecesToActivate = Random.Range(2, 5);
        HashSet<int> chosenIndices = new HashSet<int>();

        while (chosenIndices.Count < numPiecesToActivate)
        {
            int randomIndex = Random.Range(0, childTransforms.Length);
            chosenIndices.Add(randomIndex);
        }

        foreach (int index in chosenIndices)
        {
            Transform selectedTransform = childTransforms[index];
            selectedTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            Image imageComponent = selectedTransform.GetComponent<Image>();
            if (imageComponent != null)
            {
                Color originalColor = imageComponent.color;
                imageComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Set alpha to 1
            }

            selectedTransform.gameObject.SetActive(true);

            Rigidbody2D rb = selectedTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(forceDirection * Random.Range(150f, 1350f));
            }
        }
    }

    IEnumerator SetBigPiecesInactive(GameObject pieces)
    {
        float randomTime = Random.Range(30, 35);
        yield return new WaitForSeconds(randomTime);

        // Assuming Image component is used for fading (replace with the actual component type)
        Image[] imageComponents = pieces.GetComponentsInChildren<Image>();

        float fadeDuration = 4f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            foreach (Image imageComponent in imageComponents)
            {
                Color currentColor = imageComponent.color;
                imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha is completely faded out
        foreach (Image imageComponent in imageComponents)
        {
            Color currentColor = imageComponent.color;
            imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);
        }

        Choises.maxBrokenPieces -= 1;
        ObjectPool.instance.ReturnBigPiecesFromPool(pieces);
    }
    #endregion

    #region titan PIECES
    public void TitanPieces(Vector2 pos, float size)
    {
        Choises.maxBrokenPieces += 1;
        GameObject pieces = ObjectPool.instance.GetTitanPiecesFromPool();
        pieces.transform.localScale = new Vector2(size, size);
        StartCoroutine(SettitanPiecesInactive(pieces));
        pieces.transform.position = pos;

        Transform[] childTransforms = new Transform[]
           {
            pieces.transform.Find("piece1"),
            pieces.transform.Find("piece2"),
            pieces.transform.Find("piece3"),
            pieces.transform.Find("piece4"),
            pieces.transform.Find("piece5"),
            pieces.transform.Find("piece6"),
            pieces.transform.Find("piece7"),
            pieces.transform.Find("piece8"),
            pieces.transform.Find("piece9")
           };

        foreach (Transform childTransform in childTransforms)
        {
            childTransform.gameObject.SetActive(false);
            childTransform.gameObject.transform.position = pieces.transform.position;
        }

        int numPiecesToActivate = Random.Range(2, 4);
        HashSet<int> chosenIndices = new HashSet<int>();

        while (chosenIndices.Count < numPiecesToActivate)
        {
            int randomIndex = Random.Range(0, childTransforms.Length);
            chosenIndices.Add(randomIndex);
        }

        foreach (int index in chosenIndices)
        {
            Transform selectedTransform = childTransforms[index];
            selectedTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            Image imageComponent = selectedTransform.GetComponent<Image>();
            if (imageComponent != null)
            {
                Color originalColor = imageComponent.color;
                imageComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Set alpha to 1
            }

            selectedTransform.gameObject.SetActive(true);

            Rigidbody2D rb = selectedTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(forceDirection * Random.Range(150f, 1350f));
            }
        }
    }

    IEnumerator SettitanPiecesInactive(GameObject pieces)
    {
        float randomTime = Random.Range(30, 35);
        yield return new WaitForSeconds(randomTime);

        // Assuming Image component is used for fading (replace with the actual component type)
        Image[] imageComponents = pieces.GetComponentsInChildren<Image>();

        float fadeDuration = 4f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            foreach (Image imageComponent in imageComponents)
            {
                Color currentColor = imageComponent.color;
                imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha is completely faded out
        foreach (Image imageComponent in imageComponents)
        {
            Color currentColor = imageComponent.color;
            imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);
        }

        Choises.maxBrokenPieces -= 1;
        ObjectPool.instance.ReturnTitanPiecesFromPool(pieces);
    }
    #endregion

    #region heavyshot PIECES
    public void HeavyshotPieces(Vector2 pos, float size)
    {
        Choises.maxBrokenPieces += 1;
        GameObject pieces = ObjectPool.instance.GetHeavyshotPiecesFromPool();
        pieces.transform.localScale = new Vector2(size, size);
        StartCoroutine(SetHeavyshotPiecesInactive(pieces));
        pieces.transform.position = pos;

        Transform[] childTransforms = new Transform[]
           {
            pieces.transform.Find("Piece1"),
            pieces.transform.Find("Piece2"),
            pieces.transform.Find("Piece3"),
            pieces.transform.Find("Piece4"),
            pieces.transform.Find("Piece5"),
            pieces.transform.Find("Piece6"),
            pieces.transform.Find("Piece7"),
            pieces.transform.Find("Piece8")
           };

        foreach (Transform childTransform in childTransforms)
        {
            childTransform.gameObject.SetActive(false);
            childTransform.gameObject.transform.position = pieces.transform.position;
        }

        int numPiecesToActivate = Random.Range(3, 4);
        HashSet<int> chosenIndices = new HashSet<int>();

        while (chosenIndices.Count < numPiecesToActivate)
        {
            int randomIndex = Random.Range(0, childTransforms.Length);
            chosenIndices.Add(randomIndex);
        }

        foreach (int index in chosenIndices)
        {
            Transform selectedTransform = childTransforms[index];
            selectedTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

            Image imageComponent = selectedTransform.GetComponent<Image>();
            if (imageComponent != null)
            {
                Color originalColor = imageComponent.color;
                imageComponent.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1f); // Set alpha to 1
            }

            selectedTransform.gameObject.SetActive(true);

            Rigidbody2D rb = selectedTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(forceDirection * Random.Range(150f, 1350f));
            }
        }
    }

    IEnumerator SetHeavyshotPiecesInactive(GameObject pieces)
    {
        float randomTime = Random.Range(28, 33);
        yield return new WaitForSeconds(randomTime);

        // Assuming Image component is used for fading (replace with the actual component type)
        Image[] imageComponents = pieces.GetComponentsInChildren<Image>();

        float fadeDuration = 4f;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);

            foreach (Image imageComponent in imageComponents)
            {
                Color currentColor = imageComponent.color;
                imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure alpha is completely faded out
        foreach (Image imageComponent in imageComponents)
        {
            Color currentColor = imageComponent.color;
            imageComponent.color = new Color(currentColor.r, currentColor.g, currentColor.b, 0f);
        }

        Choises.maxBrokenPieces -= 1;
        ObjectPool.instance.ReturnHeavyshotPiecesFromPool(pieces);
    }
    #endregion

    #region Death Particle
    public void DeathParticle(Vector2 pos, float size)
    {
        if(SettingsOptions.disableParticleEffects == 0)
        {
            GameObject particle = ObjectPool.instance.GetEnemyDeathGlowFromPool();
            particle.transform.position = pos;
            StartCoroutine(ParticleAnim(particle, size));
            particle.GetComponent<ParticleSystem>().Play();

            //Debug.Log(pos);
            //Debug.Log(size);
        }
    }

    IEnumerator ParticleAnim(GameObject particle, float size)
    {
        float startSize = size - 0.2f;
        float growthDuration = 0.3f;
        float shrinkDuration = 0.8f;

        // Set initial size
        particle.transform.localScale = new Vector3(startSize, startSize, 1f);

        // Grow animation
        float startTime = Time.time;
        float elapsedTime = 0f;

        while (elapsedTime < growthDuration)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / growthDuration);
            float currentSize = Mathf.Lerp(startSize, size, t);
            particle.transform.localScale = new Vector3(currentSize, currentSize, 1f);
            yield return null;
        }

        // Wait for a moment
        yield return new WaitForSeconds(0.3f);

        // Shrink animation
        startTime = Time.time;
        elapsedTime = 0f;

        while (elapsedTime < shrinkDuration)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / shrinkDuration);
            float currentSize = Mathf.Lerp(size, 0f, t);
            particle.transform.localScale = new Vector3(currentSize, currentSize, 1f);
            yield return null;
        }

        // Return the particle to the object pool
        ObjectPool.instance.ReturnEnemyDeathGlowFromPool(particle);
    }
    #endregion

    public GameObject champion1Pieces, champion2Pieces, champion3Pieces, bossPieces;

    #region Champion 1 pieces
    public void Champion1Pieces(Vector2 pos, float size)
    {
   
        champion1Pieces.SetActive(true);
        champion1Pieces.transform.localScale = new Vector2(size, size);
        champion1Pieces.transform.position = pos;

        Transform[] childTransforms = new Transform[]
           {
            champion1Pieces.transform.Find("Broken1"),
            champion1Pieces.transform.Find("Broken2"),
            champion1Pieces.transform.Find("Broken3"),
           };

        foreach (Transform childTransform in childTransforms)
        {
            childTransform.gameObject.SetActive(false);
            childTransform.gameObject.transform.position = champion1Pieces.transform.position;
        }

        int numPiecesToActivate = Random.Range(3, 4);
        HashSet<int> chosenIndices = new HashSet<int>();

        while (chosenIndices.Count < numPiecesToActivate)
        {
            int randomIndex = Random.Range(0, childTransforms.Length);
            chosenIndices.Add(randomIndex);
        }

        foreach (int index in chosenIndices)
        {
            Transform selectedTransform = childTransforms[index];
            selectedTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            selectedTransform.gameObject.SetActive(true);

            Rigidbody2D rb = selectedTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(forceDirection * Random.Range(500f, 800));
            }
        }
    }
    #endregion

    #region Champion 2 pieces
    public void Champion2Pieces(Vector2 pos, float size)
    {
        champion2Pieces.SetActive(true);
        champion2Pieces.transform.localScale = new Vector2(size, size);
        champion2Pieces.transform.position = pos;

        Transform[] childTransforms = new Transform[]
           {
            champion2Pieces.transform.Find("Broken1"),
            champion2Pieces.transform.Find("Broken2"),
            champion2Pieces.transform.Find("Broken3"),
           };

        foreach (Transform childTransform in childTransforms)
        {
            childTransform.gameObject.SetActive(false);
            childTransform.gameObject.transform.position = champion2Pieces.transform.position;
        }

        int numPiecesToActivate = Random.Range(3, 4);
        HashSet<int> chosenIndices = new HashSet<int>();

        while (chosenIndices.Count < numPiecesToActivate)
        {
            int randomIndex = Random.Range(0, childTransforms.Length);
            chosenIndices.Add(randomIndex);
        }

        foreach (int index in chosenIndices)
        {
            Transform selectedTransform = childTransforms[index];
            selectedTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            selectedTransform.gameObject.SetActive(true);

            Rigidbody2D rb = selectedTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(forceDirection * Random.Range(500f, 800));
            }
        }
    }
    #endregion

    #region Champion 3 pieces
    public void Champion3Pieces(Vector2 pos, float size)
    {
        champion3Pieces.SetActive(true);
        champion3Pieces.transform.localScale = new Vector2(size, size);
        champion3Pieces.transform.position = pos;

        Transform[] childTransforms = new Transform[]
           {
            champion3Pieces.transform.Find("Broken1"),
            champion3Pieces.transform.Find("Broken2"),
            champion3Pieces.transform.Find("Broken3"),
           };

        foreach (Transform childTransform in childTransforms)
        {
            childTransform.gameObject.SetActive(false);
            childTransform.gameObject.transform.position = champion3Pieces.transform.position;
        }

        int numPiecesToActivate = Random.Range(3, 4);
        HashSet<int> chosenIndices = new HashSet<int>();

        while (chosenIndices.Count < numPiecesToActivate)
        {
            int randomIndex = Random.Range(0, childTransforms.Length);
            chosenIndices.Add(randomIndex);
        }

        foreach (int index in chosenIndices)
        {
            Transform selectedTransform = childTransforms[index];
            selectedTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            selectedTransform.gameObject.SetActive(true);

            Rigidbody2D rb = selectedTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(forceDirection * Random.Range(500f, 800));
            }
        }
    }
    #endregion


    #region Boss Pieces
    public void BossPieces(Vector2 pos, float size)
    {
        bossPieces.SetActive(true);
        bossPieces.transform.localScale = new Vector2(size, size);
        bossPieces.transform.position = pos;

        Transform[] childTransforms = new Transform[]
           {
              bossPieces.transform.Find("Broken1"),
              bossPieces.transform.Find("Broken2"),
              bossPieces.transform.Find("Broken3"),
              bossPieces.transform.Find("Broken4"),
           };

        foreach (Transform childTransform in childTransforms)
        {
            childTransform.gameObject.SetActive(false);
            childTransform.gameObject.transform.position = bossPieces.transform.position;
        }

        int numPiecesToActivate = Random.Range(4, 5);
        HashSet<int> chosenIndices = new HashSet<int>();

        while (chosenIndices.Count < numPiecesToActivate)
        {
            int randomIndex = Random.Range(0, childTransforms.Length);
            chosenIndices.Add(randomIndex);
        }

        foreach (int index in chosenIndices)
        {
            Transform selectedTransform = childTransforms[index];
            selectedTransform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            selectedTransform.gameObject.SetActive(true);

            Rigidbody2D rb = selectedTransform.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 forceDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
                rb.AddForce(forceDirection * Random.Range(1600f, 2000));
            }
        }
    }

    #endregion
}
