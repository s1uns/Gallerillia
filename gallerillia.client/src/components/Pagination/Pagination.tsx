import { FC } from "react";
import ReactPaginate from "react-paginate";
import styles from "./Pagination.module.scss";
import { PaginationProps } from "../../types/types";

export const Pagination: FC<PaginationProps> = ({
    currentPage,
    onChangePage,
    totalPages,
}) => {
    return (
        <ReactPaginate
            className={styles["pagination"]}
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
