import React from "react";
import '../styles.css';

type SearchFieldProps = {
  searchQuery: string;
  setSearchQuery: React.Dispatch<React.SetStateAction<string>>;
};

const SearchField: React.FC<SearchFieldProps> = ({
  searchQuery,
  setSearchQuery,
}) => {
  const handleSearchChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(e.target.value);
  };

  return (
    <p className="search__field f3 link dim pa3 poiter tc"><input
    type="text"
    placeholder="Search"
    value={searchQuery}
    onChange={handleSearchChange}
  /></p>
  );
};

export default SearchField;
