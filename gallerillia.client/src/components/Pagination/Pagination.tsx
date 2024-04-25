import React, { FC } from "react";
import ReactPaginate from "react-paginate";
import styles from "./Pagination.module.scss";

type PaginationProps = {
    currentPage: number;
    onChangePage: (page: number) => void;
    totalPages: number;
};

export const Pagination: FC<PaginationProps> = ({
    currentPage,
    onChangePage,
    totalPages,
}) => {
    return (
        <ReactPaginate
            className={styles.pagination}
            breakLabel="..."
            nextLabel=">"
            onPageChange={(event) => onChangePage(event.selected)}
            pageRangeDisplayed={3}
            pageCount={totalPages}
            forcePage={currentPage}
            previousLabel="<"
            renderOnZeroPageCount={null}
        />
    );
};
