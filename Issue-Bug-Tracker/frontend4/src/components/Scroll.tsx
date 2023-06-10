import React, { ReactNode } from 'react';
import './styles.css';


type ScrollProps = {
  children: ReactNode;
};

const Scroll: React.FC<ScrollProps> = ({ children }) => {
  return (
    <div style={{ overflow: 'scroll', border: '5px solid black', height: '800px' }}>
      {children}
    </div>
  );
};

export default Scroll;