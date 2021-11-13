using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapper
{
    private int _boderWidth = 250;
    private int _borderOffset = 50;
    static int _leftMin;
    static int _leftMax;
    static int _topMin;
    static int _topMax;
    static int _rightMin;
    static int _rightMax;
    static int _bottomMin;
    static int _bottomMax;

    private int _minX = 0;
    private int _minY = 0;
    private int _maxX = Screen.width;
    private int _maxY = Screen.height;

    private int _rows = 2;
    private int _cols = 2;
    private float _sectionWidth;
    private float _sectionHeight;

    public List<GameSection> gameSections;


    public GameMapper()
    {
        //set the paramters for border sections.
        _leftMin = 0 - _boderWidth;
        _leftMax = 0 - _borderOffset;
        _topMin = Screen.height + _borderOffset;
        _topMax = Screen.height + _boderWidth;
        _rightMin = Screen.width + _borderOffset;
        _rightMax = Screen.width + _boderWidth;
        _bottomMin = 0 - _boderWidth;
        _bottomMax = 0 - _borderOffset;

        //Calculate the dimensions for game areas.
        _sectionWidth = _maxX/_cols;
        _sectionHeight = _maxY/_rows;

        gameSections = new List<GameSection>();

        this.GenerateGameSections();
    }
    private void GenerateGameSections()
    {
        //add left border sections
        gameSections.Add(new GameSection(minX: _leftMin, maxX: _leftMax, minY:_bottomMin, maxY:_maxY));
        //add top border section
        gameSections.Add(new GameSection(minX: _leftMin, maxX: _rightMax, minY: _topMin, maxY: _topMax));
        //add riht border section
        gameSections.Add(new GameSection(minX: _rightMin, maxX: _rightMax, minY: _bottomMin, maxY: _topMax));
        //add bottom border section
        gameSections.Add(new GameSection(minX: _leftMin, maxX: _rightMax, minY: _bottomMin, maxY: _bottomMax));
        //add main game section
        gameSections.Add(new GameSection(minX: _minX, maxX: Screen.width, minY: _minY, maxY: Screen.height));
        //add game sections
        //var minX = 0f;
        //var maxX = _sectionWidth;
        //var minY = 0f;
        //var maxY = _sectionHeight;
        //for(var i =0; i< _rows; i++)
        //{
        //    for(var j = 0; j<_cols; j++)
        //    {
        //        gameSections.Add(new GameSection(minX:minX,maxX:maxX, minY:minY, maxY:maxY ));
        //        minX += _sectionWidth;
        //        maxX += _sectionWidth;
        //    }
        //    minX = 0;
        //    maxX = _sectionWidth;
        //    minY += _sectionHeight;
        //    maxY += _sectionHeight;
        //}
    }
    public Vector3 GetSpawnPosition()
    {
        var sectionIndex = Random.Range(0, 3);
        return gameSections[sectionIndex].GetRandomPosition();
    }
    public Vector3 GetRandomPosition()
    {
        return gameSections[4].GetRandomPosition();
    }
    
}
