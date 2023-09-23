import React, { useState } from 'react';
import { createRoot } from 'react-dom/client';

const rowStyle = {
  display: 'flex'
}

const squareStyle = {
  'width':'60px',
  'height':'60px',
  'backgroundColor': '#ddd',
  'margin': '4px',
  'display': 'flex',
  'justifyContent': 'center',
  'alignItems': 'center',
  'fontSize': '20px',
  'color': 'white'
}

const boardStyle = {
  'backgroundColor': '#eee',
  'width': '208px',
  'alignItems': 'center',
  'justifyContent': 'center',
  'display': 'flex',
  'flexDirection': 'column',
  'border': '3px #eee solid'
}

const containerStyle = {
  'display': 'flex',
  'alignItems': 'center',
  'flexDirection': 'column'
}

const instructionsStyle = {
  'marginTop': '5px',
  'marginBottom': '5px',
  'fontWeight': 'bold',
  'fontSize': '16px',
}

const buttonStyle = {
  'marginTop': '15px',
  'marginBottom': '16px',
  'width': '80px',
  'height': '40px',
  'backgroundColor': '#8acaca',
  'color': 'white',
  'fontSize': '16px',
}

function Square(props) {
  return (
    <div
      className="square"
      style={props.isPartOfAMatch ? {...squareStyle, backgroundColor: "blue"}: squareStyle}
      onClick={() => props.onClick(props.position)}>
      <h1>{props.value || ""}</h1>
    </div>
  );
}

function Board() {
  const [squares, setSquares] = useState(Array(9).fill(null));
  const [xIsNext, setXIsNext] = useState(true);
  const [winnerInfo, setWinnerInfo] = useState(null);

  function isAMatch(squares) {
    const possibleMatches = [
      [0, 1, 2],
      [3, 4, 5],
      [6, 7, 8],
      [0, 3, 6],
      [1, 4, 7],
      [2, 5, 8],
      [0, 4, 8],
      [2, 4, 6]
    ];

    for(let i =0; i < possibleMatches.length; i++){
      const [a, b, c] = possibleMatches[i];
      if(squares[a] && squares[a] === squares[b] && squares[a] === squares[c]) {
        setWinnerInfo({winner: squares[a], winningLine: [a, b, c]})
        return true;
      }
    }
    return null;
  }
  let handleSquareClicked = (index) => {
    const squaresLocal = squares.slice();

    //Dont allow clicking in a filled square || check if squares matches an winner set
    if(squaresLocal[index] || isAMatch(squares)) return;

    //fill the clicked square and update board
    squaresLocal[index] = xIsNext ? "X" : "O";
    setXIsNext(!xIsNext);
    setSquares(squaresLocal);

    //check if the last move is an winner move
    isAMatch(squaresLocal);
  }

  let handleResetClick = () => {
    setSquares(Array(9).fill(null));
    setXIsNext(true);
    setWinnerInfo(null);
  }

  return (
    <div style={containerStyle} className="gameBoard">
      <div id="statusArea" className="status" style={instructionsStyle}>
        Next player: <span>{xIsNext ? "X" : "O"}</span>
      </div>
      <div id="winnerArea" className="winner" style={instructionsStyle}>
        Winner: <span>{winnerInfo ? winnerInfo.winner : "None"}</span>
      </div>
      <button 
        style={buttonStyle} 
        onClick={handleResetClick}
      >
        Reset
      </button>
      <div style={boardStyle}>
        <div className="board-row" style={rowStyle}>
          <Square 
            value={squares[0]} 
            position={0} 
            onClick={handleSquareClicked}
            isPartOfAMatch={winnerInfo && winnerInfo.winningLine.includes(0)}
          />
          <Square 
            value={squares[1]} 
            position={1} 
            onClick={handleSquareClicked}
            isPartOfAMatch={winnerInfo && winnerInfo.winningLine.includes(1)}
          />
          <Square 
            value={squares[2]} 
            position={2} 
            onClick={handleSquareClicked}
            isPartOfAMatch={winnerInfo && winnerInfo.winningLine.includes(2)}
          />
        </div>
        <div className="board-row" style={rowStyle}>
          <Square 
            value={squares[3]} 
            position={3} 
            onClick={(e) => handleSquareClicked(e)}
            isPartOfAMatch={winnerInfo && winnerInfo.winningLine.includes(3)}
          />
          <Square 
            value={squares[4]} 
            position={4} 
            onClick={(e) => handleSquareClicked(e)}
            isPartOfAMatch={winnerInfo && winnerInfo.winningLine.includes(4)}
          />
          <Square 
            value={squares[5]} 
            position={5} 
            onClick={(e) => handleSquareClicked(e)}
            isPartOfAMatch={winnerInfo && winnerInfo.winningLine.includes(5)}
          />
        </div>
        <div className="board-row" style={rowStyle}>
          <Square 
            value={squares[6]} 
            position={6} 
            onClick={(e) => handleSquareClicked(e)}
            isPartOfAMatch={winnerInfo && winnerInfo.winningLine.includes(6)}
          />
          <Square 
            value={squares[7]} 
            position={7} 
            onClick={(e) => handleSquareClicked(e)}
            isPartOfAMatch={winnerInfo && winnerInfo.winningLine.includes(7)}
          />
          <Square 
            value={squares[8]} 
            position={8} 
            onClick={(e) => handleSquareClicked(e)}
            isPartOfAMatch={winnerInfo && winnerInfo.winningLine.includes(8)} 
          />
        </div>
      </div>
    </div>
  );
}

function Game() {
  return (
    <div className="game">
      <div className="game-board">
        <Board />
      </div>
    </div>
  );
}

const container = document.getElementById('root');
const root = createRoot(container);
root.render(<Game />);