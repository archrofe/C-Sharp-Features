using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper2D
{
    public class Grid : MonoBehaviour
    {
        public enum MineState
        {
            LOSS = 0,
            WIN = 1
        }
        public enum MouseButton
        {
            LEFT_MOUSE = 0,
            RIGHT_MOUSE = 1,
            MIDDLE_MOUSE = 2
        }
        public GameObject tilePrefab;
        public int width = 10;
        public int height = 10;
        public float spacing = .155f;
        public float offset = .5f;

        private Tile[,] tiles;

        // Functionality for spawning tiles
        Tile SpawnTile(Vector3 pos)
        {
            // Clone tile prefab
            GameObject clone = Instantiate(tilePrefab);
            clone.transform.position = pos; // Position tile
            Tile currentTile = clone.GetComponent<Tile>();  // Get Tile component
            return currentTile; // Return it
        }

        // Spawns tiles in a grid-like pattern
        void GenerateTiles()
        {
            // Create new 2D array of size width x height
            tiles = new Tile[width, height];

            // Loop through the entire tile list
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Store half size for later use
                    Vector2 halfSize = new Vector2(width / 2, height / 2);
                    // Pivot tiles around Grid
                    Vector2 pos = new Vector2(x - (halfSize.x - offset), y - (halfSize.y - offset));
                    // Apply spacing
                    pos *= spacing;
                    // Spawn the tile
                    Tile tile = SpawnTile(pos);
                    // Attach newly spawned tile to
                    tile.transform.SetParent(transform);
                    // Store it's array coordinates within itself for future reference
                    tile.x = x;
                    tile.y = y;
                    // Store tile in array at those coordinates
                    tiles[x, y] = tile;
                }
            }

            GetAdjacentMineCountAt(tiles[0, 0]);
        }

        // Use this for initialization
        void Start()
        {
            // Generate tiles on startup
            GenerateTiles();
        }

        void Update()
        {
            // IF Mouse Button 0 is Down
                // LET ray = Ray from Camera using Input.mousePosition
                // LET hit = Physic2D RayCast (ray.origin, ray.direction)
                // IF hit's collider != null
                    // LET hitTile = hit collider's Tile component
                    // IF hitTile != null
                        // CALL SelectTile(hitTile)
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
                if (hit.collider != null)
                {
                    // LET tile = hit collider's Tile component
                    Tile t = hit.collider.GetComponent<Tile>();
                    // IF tile != null
                    if (t != null)
                    {
                        // LET adjacentMines = GetAdjacentMinesAt(tile)
                        int adjacentMines = GetAdjacentMineCountAt(t);
                        // CALL tile.Reveal(adjacentMines)
                        t.Reveal(adjacentMines);
                    }
                }
            }
        }

        // Count adjacent mines at element
        public int GetAdjacentMineCountAt(Tile t)
        {
            int count = 0;
            // Loop through all elements and have each axis go between -1 to 1
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    // Calculate desired coordinates from ones attained
                    int desiredX = t.x + x;
                    int desiredY = t.y + y;

                    // IF desiredX is within range of tiles array length
                    if (desiredX >= 0 && desiredY >= 0 && desiredX < width && desiredY < height)
                    {
                        Tile tile = tiles[desiredX, desiredY];
                        // IF the element at index is a mine
                        if (tile.isMine)
                        {
                            // Increment count by 1
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        public void FFuncover(int x, int y, bool[,] visited)
        {
            // IF x >= 0 AND y >= 0 AND x < width AND y < height
            if (x >= 0 && y >= 0 && x < width && y < height)
            {
                // IF visited[x, y]
            }
            // RETURN

            // Let tile = tiles[x, y]
            // Let adjacentMines = GetAdjacentMineCountAt(tile
            // CALL tile.Reveal(adjacentMines)

            // IF adjacentMines > 0
            // RETURN

            // SET visited[x, y] = true

            //CALL FFuncove(x - 1, y, visited)
            //CALL FFuncove(x + 1, y, visited)
            //CALL FFuncove(x, y - 1, visited)
            //CALL FFuncove(x, y + 1, visited)
        }

        // Uncovers all minesthat are in the grid
        public void UncoverMines(int mineState)
        {
            // FOR x = 0 to x < width
                // FOR y = 0 to y < height
                    // LET currentTile = tiles[x, y]
                    // IF currentTile isMine
                        // LET adjacentMines = GetAdjacentMineCountAt(currentTile)
                        // Call currentTile.Reveal(adjacentMines, mineState)
        }

        // Detects if there are no more empty tiles in the game
        bool NoMoreEmptyTiles()
        {
            // LET emptyTileCount = 0
            int emptyTileCount = 0;
            // FOR x = 0 to x < width
            // FOR y = 0 to y < height
            // LET currentTile = tiles[x, y]
            // IF !currentTile.isRevealed AND !current.isMine
            // SET emptyTileCount = emptyTileCount + 1
            // RETURN emptyTileCount
            return emptyTileCount == 0;
        }

        public void SelectTile(Tile selectedTile)
        {
            // LET adjacentMines = GetAdjacentMineCountAt(selectedTile)
            // CALL selectedTile.Reveal(adjacentMines)
            // IF selectedTile isMine
                // CALL UncoverMines(0)
                // [EXTRA] Perform Game over logic
            // ELSEIF adjacentMines == 0
                // LET x = selectedTile.x
                // LET y = selectedTile.y
                // CALL FFuncover(x, y, new bool[width, height])
            // IF NoMoreEmptyTiles()
                // CALL UncoverMines(1)
                // [EXTRA] Perform Win logic
        }
    }
}